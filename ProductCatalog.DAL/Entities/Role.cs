using System.Collections.Generic;

namespace ProductCatalog.DAL.Entities
{
    public class Role : IBaseEntity, ISoftDelete
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
