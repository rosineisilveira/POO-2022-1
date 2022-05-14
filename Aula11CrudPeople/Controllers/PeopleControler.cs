using System.Collections.Generic;
using Aula11CrudPeople.Model.Domain;
using Aula11CrudPeople.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aula11CrudPeople.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
         private IPersonRepository repository;
        public PeopleController(IPersonRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]

        public IEnumerable<Person>Get()
        {
            return repository.GetALL();
        }

        [HttpPost()]

        public IActionResult Post([FromBody]Person person)
        {
            repository.Create(person);
            return Ok(person);
         }
    }    
    
}