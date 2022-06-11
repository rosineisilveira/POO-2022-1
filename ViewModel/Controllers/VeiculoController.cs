using Microsoft.AspNetCore.Mvc;
using ViewModel.models.domain;
using ViewModel.models.repository;

namespace ViewModel.Controllers;

[ApiController]
[Route("[controller]")]

    public class VeiculoController : ControllerBase
    {
        
        private IVeiculoRepository repository;
        public VeiculoController(IVeiculoRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public async Task<IActionResult>GetAsinc()
        {
            var car = await repository.GetAllAsinc(); 
            return Ok(car);
        }
        
       
        [HttpPost()]
  
        public IActionResult Post([FromBody]Veiculo veiculo)
        {
            repository.Create(veiculo);
            return Ok(veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]Veiculo veiculo)
        {
            var c = repository.GetByIdAsinc(id);
            if ( c  == null)
            {
                 return Ok(new
            {
                message = "Veiculo não encontrado!!!  " 
            });    

            }
            else
            {
                repository.Update(veiculo,id);
            } 
            
            return Ok(veiculo);
           
        }

        [HttpDelete("{id}")]
        public  IActionResult Delete(int id,[FromBody]Veiculo veiculo)
        {
            var c = repository.GetByIdAsinc(id);
            if(c == null)
            {
                 return Ok(new
            {
                message = "veiculo nao encontrado!!!  " 
            });
            }
            else
            {
                repository.Delete(id);
            }
           return Ok();
           
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetAsinc(int id,[FromBody]Veiculo veiculo)
        {
            var car = await repository.GetByIdAsinc(id); 
            return Ok(car);
           
           
        }
        
    }
