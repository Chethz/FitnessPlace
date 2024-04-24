using AutoMapper;
using FitnessPlace.Business.DTOs;
using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Services
{
    public class MemberService
    {
        private readonly IMapper _mapper;
        public readonly IGenericRepository<Member> _membersRepository;

        public MemberService(IGenericRepository<Member> memberRepository, IMapper mapper)
        {
            _mapper = mapper;
            _membersRepository = memberRepository;
        }

        public async Task<IList<MemberDto>> GetAsync(bool tracked = true)
        {
            try
            {
                var result = _membersRepository.GetAsync();
                return _mapper.Map<IList<MemberDto>>(result);
            }
            catch
            {
                throw new Exception("");
            }
        }
    }
}