using FitnessPlace.DataAccess.Specifications;

namespace FitnessPlace.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAsync(bool tracked = true);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetWithSpecificationAsync(Specification<T> specification = null);
        Task<T> GetByIdWithSpecificationAsync(Specification<T>? specification = null);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task SaveAsync();
    }
}