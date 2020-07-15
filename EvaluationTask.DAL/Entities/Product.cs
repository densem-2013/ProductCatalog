using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTask.DAL.Entities
{
    public class Product
    {
        public Product()
        {
            ProductSpecFields = new HashSet<ProductSpecField>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductSpecField> ProductSpecFields { get; set; }
    }
}
