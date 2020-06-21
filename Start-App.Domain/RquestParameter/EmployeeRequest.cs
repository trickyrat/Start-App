// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

namespace Start_App.Domain.RquestParameter
{
    public class EmployeeRequest
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public string SearchTerm { get; set; }
        public string EmployeeName { get; set; }
    }
}
