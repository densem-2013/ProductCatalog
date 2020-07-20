using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.DAL.Models.Categories
{
    public class UpdateCategoryModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
