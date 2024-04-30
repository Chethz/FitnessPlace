using System.Linq.Expressions;

namespace FitnessPlace.Business.Services.IServices
{
    public interface IMemberService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<IEnumerable<TDto>> GetAsync(bool tracked = true);
        Task<TDto?> GetByIdAsync(int id);
        Task<List<TDto?>> GetWithMemberDetailsAsync(Expression<Func<TEntity, object>> include);
    }
}