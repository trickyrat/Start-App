using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Domain.Entities;
using Start_App.Domain.Dtos;
using Start_App.Application.V2.Interface;
using Start_App.Domain.Common;
using Start_App.Domain.Requests;

namespace Start_App.V2.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [OpenApiTag("Employees", Description = "Development environment")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [MapToApiVersion("2")]
        [ProducesResponseType(typeof(PagedList<EmployeeDto>), 200)]
        public IActionResult Employees([FromQuery] EmployeeRequest request)
        {
            PagedList<EmployeeDto> employees = _repository.GetEmployees(request);
            return new JsonResult(employees);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [MapToApiVersion("2")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Employee([FromQuery] int Id)
        {
            var employee = _repository.GetEmployeeById(Id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return new JsonResult(employeeDto);
        }

    }
}
