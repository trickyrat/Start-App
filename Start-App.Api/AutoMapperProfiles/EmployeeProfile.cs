// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using AutoMapper;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;
using Start_App.Helper;

namespace Start_App.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityId));


            CreateMap<PagedList<Employee>, PagedList<EmployeeDto>>()
                .ForCtorParam("data", opt => opt.MapFrom(src => src.Data))
                .ForCtorParam("count", opt => opt.MapFrom(src => src.TotalCount))
                .ForCtorParam("pageIndex", opt => opt.MapFrom(src => src.PageIndex))
                .ForCtorParam("pageSize", opt => opt.MapFrom(src => src.PageSize))
                .ForCtorParam("sortColumn", opt => opt.MapFrom(src => src.SortColumn))
                .ForCtorParam("sortOrder", opt => opt.MapFrom(src => src.SortOrder))
                .ForCtorParam("filterColumn", opt => opt.MapFrom(src => src.FilterColumn))
                .ForCtorParam("filterQuery", opt => opt.MapFrom(src => src.FilterQuery));
        }
    }
}
