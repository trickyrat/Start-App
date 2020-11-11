using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Domain.Entities;
using Start_App.Domain.Dtos;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;
using Start_App.Service.V1;

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
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(PagedList<EmployeeDto>), 200)]
        public async Task<IActionResult> Employees([FromQuery] EmployeeRequest request)
        {
            PagedList<Employee> employees = await _repository.GetEmployeesAsync(request);
            var employeeDtos = _mapper.Map<PagedList<Employee>, PagedList<EmployeeDto>>(employees);
            return new JsonResult(employeeDtos);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(Employee), 200)]
        public async Task<IActionResult> Employees([FromQuery] int Id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(Id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return new JsonResult(employeeDto);
        }
    }
}
