using System.Linq.Expressions;
using FitnessPlace.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlace.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FitnessPlaceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(FitnessPlaceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T?>> GetAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            try
            {
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<T?>> GetWithMemberDetailsAsync(Expression<Func<T, object>> include)
        {
            IQueryable<T> query = _dbSet;

            return await query.Include(include).ToListAsync();
        }
    }
}