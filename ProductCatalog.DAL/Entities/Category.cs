using System.Collections.Generic;

namespace ProductCatalog.DAL.Entities
{
    public class Category : IBaseEntity
    {
        public Category()
        {
            SpecFields = new HashSet<SpecField>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public bool? Deleted { get; set; }

        public ICollection<SpecField> SpecFields { get; set; }
    }
}
