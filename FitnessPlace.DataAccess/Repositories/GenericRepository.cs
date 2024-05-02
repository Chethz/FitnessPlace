using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Specifications;
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

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<T?>> GetAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetWithSpecificationAsync(Specification<T>? specification = null)
        {
            IQueryable<T?> query = _dbSet;
            return await SpecificationQueryBuilder.GetQuery(query, specification).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecificationAsync(Specification<T>? specification = null)
        {
            IQueryable<T?> query = _dbSet;
            return await SpecificationQueryBuilder.GetQuery(query, specification).FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }
    }
}