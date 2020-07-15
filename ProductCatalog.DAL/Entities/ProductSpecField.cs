namespace ProductCatalog.DAL.Entities
{
    public class ProductSpecField
    {
        public int ProductId { get; set; }
        public int SpecFieldId { get; set; }

        public Product Product { get; set; }
        public SpecField SpecField { get; set; }
    }
}
