using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;


namespace Start_App.Controllers.V1
{
    [ApiVersion("1")]
    [OpenApiTag("Products", Description = "Production enviroment")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductsController : ApiController
    {

        //[HttpGet]
        //[MapToApiVersion("1")]
        //public IActionResult Products([FromQuery] ProductRequest request)
        //{
            
        //}


        //[HttpGet("ProductCategory")]
        //[MapToApiVersion("1")]
        //public IActionResult ProductCategory()
        //{
            
        //}

        //[HttpGet("ProductSubcategory")]
        //[MapToApiVersion("1")]
        //public IActionResult ProductSubCategory([FromQuery] int subCategoryId)
        //{
            
        //}


    }
}
