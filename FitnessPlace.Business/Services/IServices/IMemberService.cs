using FitnessPlace.Business.DTOs;
using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Services.IServices
{
    public interface IMemberService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(bool tracked = true);
        Task<TEntity?> GetByIdAsync(int id);
    }
}