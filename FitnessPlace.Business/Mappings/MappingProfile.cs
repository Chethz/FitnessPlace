using AutoMapper;
using FitnessPlace.Business.DTOs;
using FitnessPlace.DataAccess.Models;

namespace FitnessPlace.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<MemberDetail, MemberDetailDto>().ReverseMap();
        }
    }
}