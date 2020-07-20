using ProductCatalog.DAL;
using ProductCatalog.DAL.Entities;
using ProductCatalog.Services.Abstract;
using ProductCatalog.Services.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.WebApi
{
    public class SpecificationFieldService : Service<SpecField>, ISpecificationFieldService
    {
        public SpecificationFieldService(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<IEnumerable<SpecField>> GetByCategoryId(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SoftDelete(SpecField entity)
        {
            entity.Deleted = true;

            DbSet.Update(entity);

            return await _db.SaveChangesAsync();
        }

    }
}