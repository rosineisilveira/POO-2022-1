using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoController(IAlunoRepository repository,IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }
       
        [HttpPost()]

        public async Task<IActionResult> PostAsync([FromBody]CreateAlunoViewModel model)
        {
            var aluno = new Aluno()
            {
                Name = model.Name,
                Phone = model.Phone,
            };

            _repository.Create(aluno);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Aluno " + aluno.Name + " foi adicionado com sucesso!"
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var alunosList = await _repository.GetAllAsync();

            List<AlunoDTO> alunosDTO = new List<AlunoDTO>();

            foreach (Aluno aluno in alunosList)
            {
                var alunoDTO = new AlunoDTO()
                {
                    Name = aluno.Name,
                    Phone = aluno.Phone,
                   
                };

                alunosDTO.Add(alunoDTO);
            }

            return Ok(alunosDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id,[FromBody]Aluno aluno)
        {
            var a = _repository.GetByIdAsync(id);

            await _unitOfWork.CommitAsync();

            if(a == null)
            {
                 return Ok(new
            {
                message = "aluno nao encontrado!!!  " 
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
            var aluno = await _repository.GetByIdAsync(id);

            if(aluno == null)
                return NotFound();
            else
            {
                var alunoDTO = new AlunoDTO()
                {
                    Name = aluno.Name,
                    Phone = aluno.Phone,
                };
                return Ok(alunoDTO);
            }
        }

        [HttpPatch("{id}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateAlunoViewModel model)
        {
            var aluno = await _repository.GetByIdAsync(id);
            if (aluno == null) return NotFound();

            aluno.Name = model.Name;
            aluno.Phone = model.Phone;

            _repository.Update(aluno);
            await _unitOfWork.CommitAsync();
            return Ok(aluno);
        }

       


        
    }
}