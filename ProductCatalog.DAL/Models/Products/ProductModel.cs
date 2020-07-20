using ProductCatalog.DAL.Models.ProductSpecFields;
using System.Collections.Generic;

namespace ProductCatalog.DAL.Models.Products
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductSpecFieldModel> SpecificationData { get; set; }
    }
}
