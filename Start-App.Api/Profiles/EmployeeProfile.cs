// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using AutoMapper;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;
using Start_App.Domain.Enums;

namespace Start_App.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    dest => dest.GenderDisplay,
                    opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(
                    dest => dest.Age,
                    opt=>opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year));

            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse(typeof(Gender), src.GenderDisplay)));
        }
    }
}
