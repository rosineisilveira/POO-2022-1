using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class PlanosController : ControllerBase
    {
        private readonly IPlanosRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PlanosController(IPlanosRepository repository,IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }
        [HttpPost()]

        public async Task<IActionResult> PostAsync([FromBody]CreatePlanosViewModel model)
        {
            var planos = new Planos()
            {
                Name = model.Name,
                Valor= model.Valor,
            };

            _repository.Create(planos);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Planos " + planos.Name + " foi adicionado com sucesso!"
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var planosList = await _repository.GetAllAsync();

            List<PlanosDTO> planoDTO = new List<PlanosDTO>();

            foreach (Planos planos in planosList)
            {
                var planosDTO = new PlanosDTO()
                {
                    Name = planos.Name,
                    Valor= planos.Valor,
                    
                   
                };

                planoDTO.Add(planosDTO);
            }

            return Ok(planoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id,[FromBody]Planos planos)
        {
            var p = _repository.GetByIdAsync(id);

            await _unitOfWork.CommitAsync();

            if(p == null)
            {
                 return Ok(new
            {
                message = "Plano nao encontrado!!!  " 
            });
            }
            else
            {
                _repository.Delete(id);
            }
           return Ok();
           
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var plano = await _repository.GetByIdAsync(id);

            if(plano == null)
                return NotFound();
            else
            {
                var planosDTO = new PlanosDTO()
                {
                    Name = plano.Name,
                    Valor = plano.Valor,
                };
                return Ok(planosDTO);
            }
        }

        [HttpPatch("{id}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdatePlanosViewModel model)
        {
            var plano = await _repository.GetByIdAsync(id);
            if (plano == null) return NotFound();

            plano.Name = model.Name;
            plano.Valor = model.Valor;

            _repository.Update(plano);
            await _unitOfWork.CommitAsync();
            return Ok(plano);
        }
    }
}