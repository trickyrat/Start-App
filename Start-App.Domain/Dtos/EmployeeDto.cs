// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;

namespace Start_App.Domain.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string NationalIdnumber { get; set; }
        public short? OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool? CurrentFlag { get; set; }
    }
}
