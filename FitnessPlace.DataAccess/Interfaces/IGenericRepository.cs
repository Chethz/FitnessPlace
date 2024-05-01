using System.Linq.Expressions;

namespace FitnessPlace.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAsync(bool tracked = true);
        Task<T?> GetByIdAsync(int id);
        Task<List<T?>> GetWithIncludeAsync(Expression<Func<T, object>> include);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task SaveAsync();
    }
}