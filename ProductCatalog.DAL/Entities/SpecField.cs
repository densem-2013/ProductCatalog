using System.Collections.Generic;

namespace ProductCatalog.DAL.Entities
{
    public class SpecField : IBaseEntity, ISoftDelete
    {
        public SpecField()
        {
            ProductSpecFields = new HashSet<ProductSpecField>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductSpecField> ProductSpecFields { get; set; }
    }
}
