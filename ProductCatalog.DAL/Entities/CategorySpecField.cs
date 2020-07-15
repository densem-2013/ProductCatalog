namespace ProductCatalog.DAL.Entities
{
    public class CategorySpecField
    {
        public int CategoryId { get; set; }
        public int SpecFieldId { get; set; }

        public Category Category { get; set; }
        public SpecField SpecField { get; set; }
    }
}
