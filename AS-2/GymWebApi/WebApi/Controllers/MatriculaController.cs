using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO.MatriculaDTO;
using WebApi.ViewModel.MatriculaViewModel;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MatriculaController(
                IMatriculaRepository MatriculaRepository,
                IUnitOfWork unitOfWork
        )
        {
            this._repository = MatriculaRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost()]

        public async Task<IActionResult> PostAsync([FromBody]CreateMatriculaViewModel model)
        {
            var matricula = new Matricula()
            {
            
               Status = model.Status,
               AlunoId = model.AlunoId,
               PlanoId = model.PlanoId,
               TreinoId = model.TreinoId,

            };

            _repository.Create(matricula);
            await _unitOfWork.CommitAsync();

            return Ok(matricula);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var matriculasList = await _repository.GetAllAsync();

            List<MatriculaDto> matriculasDto = new List<MatriculaDto>();

            foreach (Matricula matricula in matriculasList)
            {
                var matriculaDto = new MatriculaDto()
                {
                    Status = matricula.Status,
                    Aluno = matricula.Aluno,
                    Plano = matricula.Plano,
                    Treinos = matricula.Treinos,   
                };

                matriculasDto.Add(matriculaDto);
            }

            return Ok(matriculasDto);
            
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id,[FromBody]Matricula matricula)
        {
           
           var matriculaDel = _repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if(matriculaDel == false)
                return Ok(new
            {
                message = "Matricula nao existe ou está ativa!!"
            });
            else
                return Ok(id); 
           
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var matricula = await _repository.GetByIdAsync(id);

            if(matricula == null)
                 return NotFound();
            else
            {
                var matriculaDto = new MatriculaDto()
                {
                    Status = matricula.Status,
                    Aluno = matricula.Aluno,
                    Plano = matricula.Plano,
                    Treinos = matricula.Treinos,
                };
                return Ok(matriculaDto);
            }
        }

        [HttpPatch("{id}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateMatriculaViewModel model)
        {
            var matricula = await _repository.GetByIdAsync(id);
            if (matricula == null) return NotFound();
                matricula.Status = model.Status;
                matricula.PlanoId = model.PlanoId;
                matricula.PagamentoId = model.PagamentoId;
                matricula.Treinos = model.Treinos;

            _repository.Update(matricula);
            await _unitOfWork.CommitAsync();
            return Ok(matricula);
        }
    }
