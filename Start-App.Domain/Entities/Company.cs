// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Start_App.Domain.Entities
{
    public class Company
    {
        public Company()
        {
            Employees = new List<Employee>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Display(Name = "省份")]
        public string Province { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        [Display(Name = "")]
        public string County { get; set; }

        /// <summary>
        /// 旗下员工
        /// </summary>
        public ICollection<Employee> Employees { get; set; }

        /// <summary>
        /// 旗下产品
        /// </summary>
        public ICollection<Product> Products { get; set; }


    }
}
