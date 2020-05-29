using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Start_App.Domain;
using System.Collections.Generic;

namespace Start_App.Controllers
{
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private static readonly IEnumerable<Person> People = new List<Person>
        {
            new Person{Id=1,Name="John" },
            new Person{Id=2,Name="Tom" },
            new Person{Id=3,Name="Jerry" },
            new Person{Id=4,Name="Jack" },
            new Person{Id=5,Name="Alpha" },
            new Person{Id=6,Name="Beta" },
        };

        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/people")]
        public IEnumerable<Person> Get()
        {
            return People;
        }
    }
}
