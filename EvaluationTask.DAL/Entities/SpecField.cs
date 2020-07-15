using System.Collections.Generic;

namespace EvaluationTask.DAL.Entities
{
    public class SpecField
    {
        public SpecField()
        {
            ProductSpecFields = new HashSet<ProductSpecField>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductSpecField> ProductSpecFields { get; set; }
    }
}
