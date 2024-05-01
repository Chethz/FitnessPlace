using System.Linq.Expressions;

namespace FitnessPlace.Business.Services.IServices
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<IEnumerable<TDto>> GetAsync(bool tracked = true);
        Task<TDto?> GetByIdAsync(int id);
    }
}