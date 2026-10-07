using Microsoft.EntityFrameworkCore;
using Unitofworkexample.Data;

namespace Unitofworkexample.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _Dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            // T => T entity jo bhi model bane rhege usko hum log dbset lege 
            _Dbset = context.Set<T>();
        }
        public async Task DeleteEntityAsync(object Id)
        {
            var Entity = await _Dbset.FindAsync(Id);
            if (Entity != null)
            {
                _Dbset.Remove(Entity);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _Dbset.ToListAsync();  
        }

        public async Task<T?> GetByIdAsync(object Id)
        {
            return await _Dbset.FindAsync(Id);
        }

        public async Task InsertAsync(T Entity)
        {
             await _Dbset.AddAsync(Entity);
        }

        public async Task SaveAsync()
        {
             await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(T Entity)
        {
           _Dbset.Update(Entity);
        }
    }
}
