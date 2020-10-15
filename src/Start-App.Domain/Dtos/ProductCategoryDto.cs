using System;
using System.Collections.Generic;
using System.Text;

namespace Start_App.Domain.Dtos
{
    public class ProductCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }


    public class ProductSubcategoryDto
    {
        public int SubCategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
