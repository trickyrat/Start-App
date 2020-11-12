using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Start_App.Application.V1.Repository;
using Start_App.Domain.Common;
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
    public class PeopleController : ControllerBase
    {
        private readonly PersonRepository _repository;
        private readonly IMapper _mapper;

        public PeopleController(PersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1")]
        [ProducesResponseType(typeof(PagedList<PersonDto>), 200)]
        public async Task<IActionResult> GetAllEmployees([FromQuery] PersonRequest request)
        {
            PagedList<Person> people = await _repository.GetPagedAllAsync(request);
            var peopleDtos = _mapper.Map<PagedList<Person>, PagedList<PersonDto>>(people);
            return Ok(peopleDtos);
        }

    }
}
