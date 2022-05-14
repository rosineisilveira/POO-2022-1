using System.Collections.Generic;
using CobrancasApi.Models.Domain;
using CobrancasApi.Models.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace CobrancasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private IClienteRepository repository;

        public ClientesController(IClienteRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public IEnumerable<Cliente>Get()
        {
            return repository.GetALL(); 
        }
        
       
        [HttpPost()]
  
        public IActionResult Post([FromBody]Cliente cliente)
        {
            repository.Create(cliente);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]Cliente cliente)
        {
            repository.Update(cliente);
           
        }
    }
}