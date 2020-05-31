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
        public async Task<IActionResult> GetCompanies()
        {
            var list = await _repository.GetCompaniesAsync();
            var dtos = _mapper.Map<IEnumerable<CompanyDto>>(list);
            return Ok(dtos);
        }

        [Route("api/companies/{companyId}")]
        [HttpGet]
        public async Task<IActionResult> GetCompany(Guid companyId)
        {
            if(!await _repository.CompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var company = await _repository.GetCompanyAsync(companyId);
            var companyDto = _mapper.Map<Company>(company);
            return Ok(companyDto);
        }

        //[Route("api/companies")]
        //[HttpPost]
        //public async Task<IActionResult> AddCompany([FromBody])
        //{

        //}

        //[Route("api/companies/{companyId}")]
        //[HttpPatch]
        //public async Task<IActionResult> UpdateCompany([FromBody])
        //{

        //}




    }
}
