using CrudCobrancas.Models.Domain;
using CrudCobrancas.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudCobrancas.Controllers;

[ApiController]
[Route("[controller]")]

    public class ChargesController : ControllerBase
    {
        private IChargeRepository repository;

         public ChargesController(IChargeRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost()]
  
        public IActionResult Post([FromBody]Charge charge)
        {
            repository.Create(charge);
            return Ok(charge);
        }

         [HttpGet()]
        public IEnumerable<Charge>Get()
        {
            return repository.GetAll();
        }

        //adicionar data de pagamennto em uma conta

        [HttpPut("{id}")]
        public IActionResult  Put(int id,[FromBody]Charge charge)
        {
             var c = repository.GetById(id);
            if ( c  == null)
            {
                 return Ok(new
            {
                message = "Conta não encontrada!!!  " 
            });    
            }
            else
            {
                repository.Update(charge,id);
            } 
            
            return Ok(charge);
           
        }
         [HttpDelete("{id}")]
        public IActionResult  Delete(int id,[FromBody]Charge charge)
        {
            var c = repository.GetById(id);
            if(c.DataPag == null)
            {
                 return Ok(new
            {
                message = "Cliente com cobrança em aberto!!!  " 
            });
            }
            else
            {
                repository.Delete(id);
            }
           return Ok();
        }
         [HttpGet("{id}")]
        public IActionResult Get(int id,[FromBody]Charge charge)
        {
            var c = repository.GetById(id);
            if ( c  == null)
            {
                 return Ok(new
            {
                message = "Conta não encontrada!!!  " 
            });    

            } 
            return Ok(c);
            
           
        }
    }
