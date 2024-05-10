namespace FitnessPlace.Business.Services.IServices
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<IEnumerable<TDto>> GetAsync(bool tracked = true);
        Task<TDto?> GetByIdAsync(int id, bool tracked = true);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(int id, TEntity entity);
        Task DeleteByIdAsync(int id);
    }
}