using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Application.Common.Models;
using Start_App.Application.HumanResources.Commands.V1.CreateEmployee;
using Start_App.Application.HumanResources.Commands.V1.DeleteEmployee;
using Start_App.Application.HumanResources.Commands.V1.UpdateEmployee;
using Start_App.Application.HumanResources.Queries.V1.GetEmployeesWithPagination;


namespace Start_App.Controllers.V1
{
    [ApiVersion("1")]
    [OpenApiTag("Employees", Description = "Production environment")]
    //[Authorize]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EmployeesController : ApiController
    {
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<ActionResult<PagedList<EmployeeDto>>> GetEmployeesWithPagination([FromQuery] GetEmployeesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<ActionResult<int>> Create(CreateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpPut("{id}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            if (id != command.BusinessEntityId)
            {
                return BadRequest();
            }
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await Mediator.Send(new DeleteEmployeeCommand { BusinessEntityId = id });
            return NoContent();
        }
    }
}
