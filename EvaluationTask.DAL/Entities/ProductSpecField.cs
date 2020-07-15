using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTask.DAL.Entities
{
    public class ProductSpecField
    {
        public int ProductId { get; set; }
        public int SpecFieldId { get; set; }

        public Product Product { get; set; }
        public SpecField SpecField { get; set; }
    }
}
