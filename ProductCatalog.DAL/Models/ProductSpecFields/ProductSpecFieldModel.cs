using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.DAL.Models.ProductSpecFields
{
    public class ProductSpecFieldModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SpecFieldId { get; set; }
        public int Name { get; set; }
        public string Value { get; set; }
    }

    public class AddSpecFieldToProductModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SpecFieldId { get; set; }
        public string Value { get; set; }
    }

    public class UpdateProductSpecFieldModel
    {
        [Required]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
