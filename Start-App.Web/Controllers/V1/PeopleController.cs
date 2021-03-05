using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Start_App.Controllers.V1
{
    [ApiVersion("1")]
    [OpenApiTag("Employees", Description = "Production environment")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PeopleController : ApiController
    {

        //[HttpGet]
        //[MapToApiVersion("v1")]
        //public async Task<ActionResult<PagedList<PersonDto>>> GetPeopleWithPagination(GetPeopleWithPaginationQuery query)
        //{
        //    return Mediator.Send(query);
        //}

    }
}
