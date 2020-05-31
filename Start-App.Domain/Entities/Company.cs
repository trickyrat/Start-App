// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Start_App.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Introduction { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Product { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
