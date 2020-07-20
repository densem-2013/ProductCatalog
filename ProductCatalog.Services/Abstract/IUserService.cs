using ProductCatalog.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.Services.Abstract
{
    public interface IUserService : IService<User>, ISoftDeletable<User>
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Create(User user, string password);
        Task<User> Update(User user, string password = null);
        Task<IEnumerable<string>> GetUserRoles(int userId);
        Task<int> AddUserToRole(int userId, int roleId);
        Task<int> RemoveUserFromRole(int userId, int roleId);
    }
}
