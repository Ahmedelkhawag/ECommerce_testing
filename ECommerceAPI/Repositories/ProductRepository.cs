using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        protected readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext dbContext):base(dbContext) 
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<Product>> GetProductInStock()
        {
          return await _context.products.Where(p=>p.StockQuantity >0).ToListAsync();
        }
    }
}
