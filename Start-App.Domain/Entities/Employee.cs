// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.ComponentModel.DataAnnotations;
using Start_App.Domain.Enums;

namespace Start_App.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string EmployeeNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeName { get; set; }

        public Gender Gender { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
