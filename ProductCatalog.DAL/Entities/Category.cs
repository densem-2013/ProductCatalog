using System.Collections.Generic;

namespace ProductCatalog.DAL.Entities
{
    public class Category : IBaseEntity, ISoftDelete
    {
        public Category()
        {
            SpecFields = new HashSet<SpecField>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }

        public ICollection<SpecField> SpecFields { get; set; }
    }
}
