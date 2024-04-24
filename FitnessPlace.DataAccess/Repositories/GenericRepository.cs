using FitnessPlace.DataAccess.Interfaces;

namespace FitnessPlace.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<List<T?>> GetAsync(bool tracked = true)
        {
            throw new NotImplementedException();
        }
    }
}