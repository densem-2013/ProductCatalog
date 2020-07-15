using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTask.DAL.Entities
{
    public class Category
    {
        public Category()
        {
            SpecFields = new HashSet<SpecField>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }

        public ICollection<SpecField> SpecFields { get; set; }
    }
}
