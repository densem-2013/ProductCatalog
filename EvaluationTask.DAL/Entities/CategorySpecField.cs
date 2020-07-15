using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTask.DAL.Entities
{
    public class CategorySpecField
    {
        public int CategoryId { get; set; }
        public int SpecFieldId { get; set; }

        public Category Category { get; set; }
        public SpecField SpecField { get; set; }
    }
}
