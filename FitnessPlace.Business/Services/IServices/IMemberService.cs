using FitnessPlace.Business.DTOs;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Services.IServices
{
    public interface IMemberService : IGenericService<Member, MemberDto>
    {
        Task<IEnumerable<MemberDto>> GetAllWithMemberDetailsSpecificationAsync();
        Task<MemberDto> GetWithMemberDetailsAsync(int id);
    }
}