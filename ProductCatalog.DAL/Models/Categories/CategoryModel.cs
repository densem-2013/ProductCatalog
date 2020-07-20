using ProductCatalog.DAL.Models.SpecialFields;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.DAL.Models.Categories
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<SpecFieldModel> SpecFields { get; set; }
    }
}
