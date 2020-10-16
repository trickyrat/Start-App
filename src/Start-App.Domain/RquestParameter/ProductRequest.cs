using System;
using System.Collections.Generic;
using System.Text;

namespace Start_App.Domain.RquestParameter
{
    public class ProductRequest : RequestBase
    {
        public int ProductCategoryId { get; set; }

        public int ProductSubcatgoryId { get; set; }

    }
}
