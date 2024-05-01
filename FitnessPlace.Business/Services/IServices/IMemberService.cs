using System.Linq.Expressions;
using FitnessPlace.Business.DTOs;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Services.IServices
{
    public interface IMemberService : IGenericService<Member, MemberDto>
    {
        Task<List<MemberDto?>> GetWithMemberDetailsAsync(Expression<Func<Member, object>> include);
    }
}