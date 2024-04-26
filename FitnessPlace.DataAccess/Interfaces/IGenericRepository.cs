namespace FitnessPlace.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T?>> GetAsync(bool tracked = true);
        Task<T?> GetByIdAsync(int id);
        
    }
}