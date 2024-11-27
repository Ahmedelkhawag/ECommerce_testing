
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ECommerceDbContext context;

        private readonly DbSet<T> dbset;

        public Repository(ECommerceDbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
           await dbset.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await GetByIdAsync(id);
             dbset.Remove(value);
            await context.SaveChangesAsync();
         }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           var values = await dbset.ToListAsync();
            return values;
        }

        public async Task<T> GetByIdAsync(int id)
        {
           var value = await dbset.FindAsync(id);
            return value;
        }

        public async Task UpdateAsync(T entity)
        {
           
             dbset.Update(entity);
            await context.SaveChangesAsync();

        }
    }
}
