using Booking.Data;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataEF
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return _dbSet.AsNoTracking(); }
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(params object[] key)
        {
            return await _dbSet.FindAsync(key);

        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWithId(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
                throw new Exception();
            _dbSet.Update(entity);
        }
    }
}
