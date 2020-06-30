// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

namespace Start_App.Domain.RquestParameter
{
    public class EmployeeRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string FilterColumn { get; set; }
        public string FilterQuery { get; set; }
    }
}
