﻿// Copyright (c) Trickyrat All Rights Reserved.
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
            CreateMap<Employee, EmployeeDto>();
            CreateMap<PagedList<Employee>, PagedList<EmployeeDto>>()
                .ForCtorParam("items", opt => opt.MapFrom(src => src.Items))
                .ForCtorParam("count", opt => opt.MapFrom(src => src.Count))
                .ForCtorParam("pageIndex", opt => opt.MapFrom(src => src.PageIndex))
                .ForCtorParam("pageSize", opt => opt.MapFrom(src => src.PageSize));
        }
    }
}
