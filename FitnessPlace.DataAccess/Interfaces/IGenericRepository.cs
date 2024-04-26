using System.Linq.Expressions;

namespace FitnessPlace.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAsync(bool tracked = true);
        Task<T?> GetByIdAsync(int id);
        Task<List<T?>> GetWithMemberDetailsAsync(Expression<Func<T, object>> include);
    }
}