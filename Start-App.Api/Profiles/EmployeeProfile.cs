using System;
using AutoMapper;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;

namespace Start_App.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    dest => dest.EmployeeName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.GenderDisplay,
                    opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(
                    dest => dest.Age,
                    opt=>opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));
        }
    }
}
