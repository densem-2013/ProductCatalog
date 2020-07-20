using System.Collections.Generic;

namespace ProductCatalog.DAL.Entities
{
    public class Product : IBaseEntity, ISoftDelete
    {
        public Product()
        {
            SpecificationData = new HashSet<ProductSpecField>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }
        public ICollection<ProductSpecField> SpecificationData { get; set; }
    }
}
