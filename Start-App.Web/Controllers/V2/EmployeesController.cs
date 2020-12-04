using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Domain.Entities;
using Start_App.Domain.Dtos;
using Start_App.Application.HumanResources.Queries.V1.GetEmployeesWithPagination;
using System.Threading.Tasks;

namespace Start_App.Controllers.V2
{
    [ApiVersion("v2")]
    [OpenApiTag("Employees", Description = "Development environment")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class EmployeesController : ApiController
    {
        //[HttpGet]
        //[Produces("application/json")]
        //[MapToApiVersion("v2")]
        //public async Task<IActionResult> Employees(GetEmployeesWithPaginationQuery query)
        //{
        //    return await Mediator.Send(query);
        //}

        //[HttpGet("{id}")]
        //[Produces("application/json")]
        //[MapToApiVersion("v2")]
        //[ProducesResponseType(typeof(Employee), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //public IActionResult Employee([FromQuery] int Id)
        //{
            
        //}

    }
}
