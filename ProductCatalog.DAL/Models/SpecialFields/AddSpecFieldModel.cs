using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.DAL.Models.SpecialFields
{
    public class AddSpecFieldModel
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
