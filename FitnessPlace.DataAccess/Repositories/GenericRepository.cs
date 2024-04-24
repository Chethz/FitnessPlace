using FitnessPlace.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlace.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FitnessPlaceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public async Task<List<T?>> GetAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }
    }
}