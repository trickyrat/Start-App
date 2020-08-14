using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Helper;
using Start_App.Service;

namespace Start_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<PagedList<EmployeeDto>> GetEmployees([FromQuery]EmployeeRequest request)
        {
            PagedList<Employee> employees = await _repository.GetEmployees(request);
            var employeeDtos = _mapper.Map<PagedList<Employee>, PagedList<EmployeeDto>>(employees);
            return employeeDtos;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDto> GetEmployeeById([FromQuery]int Id)
        {
            var employee = await _repository.GetEmployeeById(Id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        //[Authorize]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> CreateEmployee(int id, Employee employee)
        //{
        //    if(id != employee.BusinessEntityId)
        //    {
        //        return BadRequest();
        //    }


        //}
    }
}
