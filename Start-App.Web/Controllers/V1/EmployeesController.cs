using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Application.Common.Models;
using Start_App.Application.HumanResources.Queries.V1;
using Start_App.Application.V1.Interface;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;

namespace Start_App.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiVersion("1.2", Deprecated = true)]
    [OpenApiTag("Employees", Description = "Production environment")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IMapper mapper, IEmployeeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(PagedList<EmployeeDto>), 200)]
        public async Task<ActionResult<PagedList<EmployeeDto>>> GetEmployeesWithPagination([FromQuery] GetEmployeesWithPaginationQuery query)
        {
            return await MediatR.Send(query);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(EmployeeDto), 200)]
        public async Task<IActionResult> EmployeeDetails(int id)
        {
            var employee = await _repository.DetailsAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(EmployeeDto), 200)]
        public async Task<IActionResult> CreateNewEmployee([FromBody] EmployeeDto employeeDtoToCreate)
        {
            var employeeToCreate = _mapper.Map<Employee>(employeeDtoToCreate);
            var res = await _repository.AddAsync(employeeToCreate);
            return Created(Request.Path + "/" + res.BusinessEntityId, employeeDtoToCreate);
        }


        [HttpPut("{id}")]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(EmployeeDto), 200)]
        public async Task<IActionResult> ModifyEmployee(int id, [FromBody] EmployeeDto employeeDtoToUpdate)
        {
            if (id != employeeDtoToUpdate.Id)
            {
                return BadRequest();
            }
            var employee = _mapper.Map<Employee>(employeeDtoToUpdate);
            var result = await _repository.UpdateAsync(id, employee);
            if (result is false)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(EmployeeDto), 200)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (result is false)
            {
                return NotFound(); // invalid id
            }
            else
            {
                return NoContent();
            }
        }
    }
}
