using System.Linq.Expressions;
using AutoMapper;
using FitnessPlace.Business.DTOs;
using FitnessPlace.Business.Services.IServices;
using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Services
{
    public class MemberService : IMemberService<Member>
    {
        private readonly IMapper _mapper;
        public readonly IGenericRepository<Member> _membersRepository;

        public MemberService(IGenericRepository<Member> memberRepository, IMapper mapper)
        {
            _mapper = mapper;
            _membersRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAsync(bool tracked = true)
        {
            try
            {
                return await _membersRepository.GetAsync();
                // return _mapper.Map<IEnumerable<MemberDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            try
            {
                var result = await _membersRepository.GetByIdAsync(id);

                if (result is null)
                {
                    throw new Exception();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Member?>> GetWithMemberDetailsAsync(Expression<Func<Member, object>> include)
        {
            try
            {
                return await _membersRepository.GetWithMemberDetailsAsync(include);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}