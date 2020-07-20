using ProductCatalog.DAL;
using ProductCatalog.DAL.Entities;
using ProductCatalog.Services.Abstract;
using ProductCatalog.Services.Concrete;
using System.Threading.Tasks;

namespace ProductCatalog.WebApi
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<int> SoftDelete(Product entity)
        {
            entity.Deleted = true;

            DbSet.Update(entity);

            return await _db.SaveChangesAsync();
        }

    }
}