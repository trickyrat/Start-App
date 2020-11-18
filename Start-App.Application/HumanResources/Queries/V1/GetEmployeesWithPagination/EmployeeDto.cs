// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using AutoMapper;
using Start_App.Application.Common.Mappings;
using Start_App.Domain.Entities;

namespace Start_App.Application.HumanResources.Queries.V1.GetEmployeesWithPagination
{
    public class EmployeeDto : IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string NationalIDNumber { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityId));

            profile.CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.BusinessEntityId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
