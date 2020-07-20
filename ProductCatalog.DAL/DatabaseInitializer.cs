using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Helpers;
using System.Linq;

namespace ProductCatalog.DAL
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DataContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (!dbContext.Users.Any())
            {
                byte[] passwordHash, passwordSalt;

                AppHelper.CreatePasswordHash("admin", out passwordHash, out passwordSalt);

                var user = new User { Id = 1, Username = "admin", FirstName = "Manager", LastName = "User", PasswordHash = passwordHash, PasswordSalt = passwordSalt };

                dbContext.Users.Add(user);

                dbContext.SaveChanges();
            }

            if (!dbContext.Roles.Any())
            {
                dbContext.Roles.Add(new Role { Id = 1, Name = "Manager" });

                dbContext.SaveChanges();
            }

            if (!dbContext.UserRoles.Any())
            {
                dbContext.UserRoles.Add(new UserRole { UserId = 1, RoleId = 1 });

                dbContext.SaveChanges();
            }
        }
    }
}
