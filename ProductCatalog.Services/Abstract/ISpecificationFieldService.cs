using ProductCatalog.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.Services.Abstract
{
    public interface ISpecificationFieldService : IService<SpecField>
    {
        Task<IEnumerable<SpecField>> GetByCategoryId(int categoryId);
    }
}
