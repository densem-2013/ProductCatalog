using ProductCatalog.DAL;
using ProductCatalog.DAL.Entities;
using ProductCatalog.Services.Abstract;

namespace ProductCatalog.Services.Concrete
{
    public class ProductSpecialFieldService : Service<ProductSpecField>, IProductSpecialFieldService
    {
        public ProductSpecialFieldService(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
