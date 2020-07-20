using Microsoft.EntityFrameworkCore;
using ProductCatalog.DAL;
using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Helpers;
using ProductCatalog.Services.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Services.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(DataContext context) : base(context)
        {
        }

        public async Task<int> AddUserToRole(int userId, int roleId)
        {
            await _db.UserRoles.AddAsync(new UserRole { UserId = userId, RoleId = roleId });

            return await _db.SaveChangesAsync();
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await SingleOrDefaultAsync(x => x, x => x.Username == username, x => x.Include(u => u.UserRoles).ThenInclude(y => y.Role));

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!AppHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<User> Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (DbSet.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            AppHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return await Create(user);
        }

        public async Task<IEnumerable<string>> GetUserRoles(int userId)
        {
            return await SingleOrDefaultAsync(u => u.UserRoles.Select(r => r.Role.Name), u => u.Id == userId, t => t.Include(b => b.UserRoles).ThenInclude(r => r.Role));
        }

        public async Task<int> RemoveUserFromRole(int userId, int roleId)
        {
            var userRole = await _db.FindAsync<UserRole>(userId, roleId);

            if (userRole != null)
            {
                _db.UserRoles.Remove(userRole);

                return await _db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<User> Update(User userParam, string password = null)
        {
            var user = await GetByIdAsync(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (DbSet.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                AppHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            return await Update(userParam);
        }

        public async Task<int> SoftDelete(User entity)
        {
            entity.Deleted = true;

            DbSet.Update(entity);

            return await _db.SaveChangesAsync();
        }

    }
}
