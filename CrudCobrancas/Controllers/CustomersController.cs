using CrudCobrancas.Models.Domain;
using CrudCobrancas.Models.Repository;
using Microsoft.AspNetCore.Mvc;


namespace CrudCobrancas.Controllers;

[ApiController]
[Route("[controller]")]

 public class CustomersController : ControllerBase
    {
        private IClientRepository repository;

        public CustomersController(IClientRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public IEnumerable<Client>Get()
        {
            return repository.GetAll(); 
        }
        
       
        [HttpPost()]
  
        public IActionResult Post([FromBody]Client client)
        {
            repository.Create(client);
            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]Client client)
        {
            var c = repository.GetById(id);
            if ( c  == null)
            {
                 return Ok(new
            {
                message = "Cliente não encontrado!!!  " 
            });    

            }
            else
            {
                repository.Update(client,id);
            } 
            
            return Ok(client);
           
        }

        [HttpDelete("{id}")]
        public  IActionResult Delete(int id,[FromBody]Client client)
        {
            var c = repository.GetById(id);
            if(c == null)
            {
                 return Ok(new
            {
                message = "Cliente nao encontrado!!!  " 
            });
            }
            else
            {
                repository.Delete(id);
            }
           return Ok();
           
           
        }

        [HttpGet("{id}")]
        public Client Get(int id,[FromBody]Client client)
        {
            return repository.GetById(id);
            
           
        }
    }





















