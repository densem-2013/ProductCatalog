namespace ProductCatalog.DAL.Entities
{
    public class ProductSpecField : IBaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SpecFieldId { get; set; }
        public string Value { get; set; }

        public Product Product { get; set; }
        public SpecField SpecField { get; set; }
    }
}
