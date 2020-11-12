// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using AutoMapper;
using Start_App.Domain.Entities;
using Start_App.Domain.Dtos;
using Start_App.Helper;

namespace Start_App.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityId));

            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.BusinessEntityId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PagedList<Employee>, PagedList<EmployeeDto>>()
                .ForCtorParam("data", opt => opt.MapFrom(src => src.Data))
                .ForCtorParam("total", opt => opt.MapFrom(src => src.TotalCount))
                .ForCtorParam("pageIndex", opt => opt.MapFrom(src => src.PageIndex))
                .ForCtorParam("pageSize", opt => opt.MapFrom(src => src.PageSize));
        }
    }
}
