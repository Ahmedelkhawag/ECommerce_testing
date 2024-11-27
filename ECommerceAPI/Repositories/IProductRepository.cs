using ECommerceAPI.Models;

namespace ECommerceAPI.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductInStock();
    }
}
