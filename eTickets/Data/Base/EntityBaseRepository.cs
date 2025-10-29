
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        // We will be injecting our AppDbContext so that we can Access the DB from here.

        private readonly AppDbContext _context;


        public EntityBaseRepository(AppDbContext contextt)
        {

            _context = contextt;    // using a Contructor to initialize the values and Ensuring DB Access through the class


            
        }


        public async Task AddAsync(T entity)
        {


            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();





           
        }

        public async Task DeleteAsync(int id)
        {

            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {


            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return result;

        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);  
            entityEntry.State = EntityState.Modified;
           await _context.SaveChangesAsync();

           
        }
    }
}
