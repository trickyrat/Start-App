using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;
using Start_App.Domain.ResultModel;
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

        public async Task<PagedList<EmployeeDto>> GetEmployees([FromQuery]EmployeeRequest request)
        {
            PagedList<Employee> employees = await _repository.GetEmployees(request.PageIndex, request.PageSize);
            var employeeDtos = _mapper.Map<PagedList<Employee>, PagedList<EmployeeDto>>(employees);
            return employeeDtos;
            //PagedListResultModel<EmployeeDto> result = new PagedListResultModel<EmployeeDto>
            //{
            //    Data = employeeDtos,
            //    HasNext = employeeDtos.HasNext,
            //    HasPrevious = employeeDtos.HasPrevious,
            //    ResCode = 100,
            //    ResMsg = "请求成功",    
            //};
            //return result;
        }
    }
}
