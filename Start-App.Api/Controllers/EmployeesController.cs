// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Start_App.Domain.Dtos;
using Start_App.Service;

namespace Start_App.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _repository;

        public EmployeesController(IMapper mapper, ICompanyRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(Guid companyId)
        {
            if (!await _repository.CompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var employees = await _repository.GetEmployeesAsync(companyId);
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid companyId, Guid employeeId)
        {
            if (!await _repository.CompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var employee = await _repository.GetEmployeeAsync(companyId, employeeId);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }
    }
}
