using System.Linq.Expressions;
using AutoMapper;
using FitnessPlace.Business.DTOs;
using FitnessPlace.Business.Services.IServices;
using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Services
{
    public class MemberService : IMemberService<Member, MemberDto>
    {
        private readonly IMapper _mapper;
        public readonly IGenericRepository<Member> _membersRepository;

        public MemberService(IGenericRepository<Member> memberRepository, IMapper mapper)
        {
            _mapper = mapper;
            _membersRepository = memberRepository;
        }

        public async Task<IEnumerable<MemberDto>> GetAsync(bool tracked)
        {
            try
            {
                var result = await _membersRepository.GetAsync();
                return _mapper.Map<IEnumerable<MemberDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MemberDto> GetByIdAsync(int id)
        {
            try
            {
                var result = await _membersRepository.GetByIdAsync(id);

                if (result is null)
                {
                    throw new Exception();
                }
                return _mapper.Map<MemberDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MemberDto?>> GetWithMemberDetailsAsync(Expression<Func<Member, object>> include)
        {
            try
            {
                var result = await _membersRepository.GetWithMemberDetailsAsync(include);
                return _mapper.Map<List<MemberDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}