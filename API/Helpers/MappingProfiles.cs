using AutoMapper;
using Core.Entities;
using API.Dtos;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Photograph, PhotographToReturnDto>()
               .ForMember(d => d.PhotographLocation,
                          memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.PhotographLocation.Name));
        }
    }
}