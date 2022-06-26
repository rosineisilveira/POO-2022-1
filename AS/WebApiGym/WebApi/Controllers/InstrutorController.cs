using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class InstrutorController : ControllerBase
    {
        private readonly IInstrutorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public InstrutorController(IInstrutorRepository _repository,IUnitOfWork _unitOfWork)
        {
            this._repository = _repository;
            this._unitOfWork = _unitOfWork;
        }
         [HttpPost()]

        public async Task<IActionResult> PostAsync([FromBody]CreateInstrutorViewModel model)
        {
            var instrutor = new Instrutor()
            {
                Name = model.Name,
               
            };

            _repository.Create(instrutor);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Instrutor " + instrutor.Name + " foi adicionado com sucesso!"
            });
        }
         [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var instrutorList = await _repository.GetAllAsync();

            List<InstrutorDTO> instrutoresDTO = new List<InstrutorDTO>();

            foreach(Instrutor instrutor in instrutorList)
            {
                var instrutorDTO = new InstrutorDTO()
                {
                    Name = instrutor.Name,  
                };

                instrutoresDTO.Add(instrutorDTO);
            }

            return Ok(instrutoresDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id,[FromBody]Instrutor instrutor)
        {
            var i = _repository.GetByIdAsync(id);

            await _unitOfWork.CommitAsync();

            if(i == null)
            {
                 return Ok(new
            {
                message = "Instrutor nao encontrado!!!  " 
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
            var instrutor = await _repository.GetByIdAsync(id);

            if(instrutor == null)
                return NotFound();
            else
            {
                var instrutorDTO = new InstrutorDTO()
                {
                    Name = instrutor.Name,
                    
                };
                return Ok(instrutorDTO);
            }
        }

        [HttpPatch("{id}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateInstrutorViewModel model)
        {
            var instrutor = await _repository.GetByIdAsync(id);
            if (instrutor == null) return NotFound();

            instrutor.Name = model.Name;

            _repository.Update(instrutor);
            await _unitOfWork.CommitAsync();
            return Ok(instrutor);
        }

    }
}