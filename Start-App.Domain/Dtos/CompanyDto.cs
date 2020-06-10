// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;

namespace Start_App.Domain.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Introduction { get; set; }
        public string Country { get; set; }
        public string Product { get; set; }
    }
}
