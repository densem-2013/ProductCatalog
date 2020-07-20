using ProductCatalog.DAL.Entities;
using System.Threading.Tasks;

namespace ProductCatalog.Services.Abstract
{
    public interface IProductService : IService<Product>, ISoftDeletable<Product>
    {
        //Task<int> AddSpecialFieldToProduct(ProductSpecField productSpecField);
        //Task<int> AddSpecialFieldToProduct(ProductSpecField productSpecField);
    }
}
