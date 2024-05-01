using System.Linq.Expressions;
using AutoMapper;
using FitnessPlace.Business.DTOs;
using FitnessPlace.Business.Exceptions;
using FitnessPlace.Business.Services.IServices;
using FitnessPlace.DataAccess.Interfaces;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Services
{
    public class MemberService : IGenericService<Member, MemberDto>, IMemberService
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
            var result = await _membersRepository.GetAsync() ?? throw new EntityNotFoundException("Members not found.");
            return _mapper.Map<IEnumerable<MemberDto>>(result);
        }

        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var result = await _membersRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Member not found.");
            return _mapper.Map<MemberDto>(result);
        }

        public async Task<List<MemberDto?>> GetMemberWithDetailsAsync()
        {
            var result = await _membersRepository.GetWithIncludeAsync(item => item.MemberDetail) ?? throw new EntityNotFoundException("Member not found.");
            return _mapper.Map<List<MemberDto?>>(result);
        }
    }
}