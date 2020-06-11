// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_App.Data;
using Start_App.Domain.Dtos;
using Start_App.Domain.Entities;
using Start_App.Domain.RquestParameter;
using Start_App.Service;

namespace Start_App.Controllers
{
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository)); 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Route("api/companies")]
        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery]CompanyRequest request)
        {
            var list = await _repository.GetCompaniesAsync(request);
            var dtos = _mapper.Map<IEnumerable<CompanyDto>>(list);
            return Ok(dtos);
        }

        [Route("api/companies/{companyId}")]
        [HttpGet]
        public async Task<IActionResult> GetCompany(int companyId)
        {
            if(!await _repository.CompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var company = await _repository.GetCompanyAsync(companyId);
            var companyDto = _mapper.Map<Company>(company);
            return Ok(companyDto);
        }

        [Route("api/companies/addcompany")]
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            var res = _repository.AddCompany(company);
            bool flag = await _repository.SaveAsync();
            return new ObjectResult(_mapper.Map<CompanyDto>(res)) { StatusCode = StatusCodes.Status201Created };
        }


        //[Route("api/companies/{companyId}")]
        //[HttpPatch]
        //public async Task<IActionResult> UpdateCompany([FromBody])
        //{

        //}




    }
}
