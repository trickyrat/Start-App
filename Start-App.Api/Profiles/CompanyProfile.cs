using AutoMapper;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;

namespace Start_App.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(
                dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.Name));

        }
    }
}
