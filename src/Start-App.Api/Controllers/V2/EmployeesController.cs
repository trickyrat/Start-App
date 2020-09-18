using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;
using Start_App.V2.Service;

namespace Start_App.V2.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [OpenApiTag("Employees", Description = "New Api")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IMapper mapper, IEmployeeRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [MapToApiVersion("2")]
        [ProducesResponseType(typeof(PagedList<EmployeeDto>), 200)]
        public IActionResult Employees([FromQuery] EmployeeRequest request)
        {
            PagedList<Employee> employees = _repository.GetEmployees(request);
            var employeeDtos = _mapper.Map<PagedList<Employee>, PagedList<EmployeeDto>>(employees);
            return new JsonResult(employeeDtos);
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
