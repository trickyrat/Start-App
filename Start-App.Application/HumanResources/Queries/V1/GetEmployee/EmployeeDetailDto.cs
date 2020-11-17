/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using AutoMapper;
using Start_App.Application.Common.Mappings;
using Start_App.Domain.Entities;

namespace Start_App.Application.HumanResources.Queries.V1.GetEmployee
{
    public class EmployeeDetailDto : IMapFrom<Employee>
    {
        public int Id { get; set; }
        public string NationalIdnumber { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool? SalariedFlag { get; set; }
        public bool? CurrentFlag { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityId));
        }

    }
}
