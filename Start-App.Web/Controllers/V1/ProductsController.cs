using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Application.Common.Models;
using Start_App.Application.Production.Queries.V1.GetProduct;
using Start_App.Application.Production.Queries.V1.GetProductCategory;
using Start_App.Application.Production.Queries.V1.GetProductSubcategory;

namespace Start_App.Controllers.V1
{
    [ApiVersion("v1")]
    [OpenApiTag("Products", Description = "Production environment")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductsController : ApiController
    {

        [HttpGet]
        [MapToApiVersion("v1")]
        public async Task<ActionResult<PagedList<ProductDto>>> Products([FromQuery] GetProductsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpGet("Category")]
        [MapToApiVersion("v1")]
        public async Task<ActionResult<List<ProductCategoryDto>>> ProductCategoryList([FromRoute]GetProductCategoryQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("Category/{id}")]
        [MapToApiVersion("v1")]
        public async Task<ActionResult<List<ProductSubcategoryDto>>> ProductSubCategory([FromRoute]GetProductSubcategoryQuery query)
        {
            return await Mediator.Send(query);
        }


    }
}
