using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.DAL.Entities
{
    public interface ISoftDelete
    {
        bool? Deleted { get; set; }
    }
}
