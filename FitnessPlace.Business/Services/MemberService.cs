using AutoMapper;
using FitnessPlace.Business.DTOs;
using FitnessPlace.Business.Exceptions;
using FitnessPlace.Business.Services.IServices;
using FitnessPlace.Business.Specifications;
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
            var result = await _membersRepository.GetAsync();
            if (!result.Any())
            {
                throw new EntityNotFoundException("Members not found.");
            }
            return _mapper.Map<IEnumerable<MemberDto>>(result);
        }

        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var result = await _membersRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Member not found.");
            return _mapper.Map<MemberDto>(result);
        }

        public async Task<IEnumerable<MemberDto>> GetAllWithMemberDetailsSpecificationAsync()
        {
            var spec = new MemberWithDetails();
            var result = await _membersRepository.GetWithSpecificationAsync(spec);
            if (!result.Any())
            {
                throw new EntityNotFoundException("Members not found.");
            }
            return _mapper.Map<List<MemberDto>>(result);
        }

        public async Task<MemberDto> GetWithMemberDetailsAsync(int id)
        {
            var spec = new MemberWithDetails(id);
            var result = await _membersRepository.GetByIdWithSpecificationAsync(spec) ?? throw new EntityNotFoundException("Member not found.");
            return _mapper.Map<MemberDto>(result);
        }

        public async Task AddAsync(Member entity)
        {
            await _membersRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, Member entity)
        {
            // var member = await _membersRepository.GetByIdAsync(id, false) ?? throw new EntityNotFoundException("Member Not found.");
            entity.Id = id;
            // if (member.Id != id)
            // {
            //     throw new EntityNotFoundException("Member Not found."); // change to bad entity request
            // }
            await _membersRepository.UpdateAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var member = await _membersRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Member Not found.");
            await _membersRepository.DeleteByIdAsync(id);
        }
    }
}