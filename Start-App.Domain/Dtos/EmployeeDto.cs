// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;
using System.Text;
using Start_App.Domain.Enums;

namespace Start_App.Domain.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string GenderDisplay { get; set; }
        public int Age { get; set; }
    }
}
