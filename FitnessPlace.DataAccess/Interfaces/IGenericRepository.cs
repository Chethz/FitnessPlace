namespace FitnessPlace.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T?>> GetAsync(bool tracked = true);
    }
}