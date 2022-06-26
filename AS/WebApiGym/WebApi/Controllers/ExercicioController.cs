using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ExercicioController(IExercicioRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost()]

        public async Task<IActionResult> PostAsync([FromBody] CreateExercicioViewModel model)
        {
            var exercicio = new Exercicio()
            {
                Name = model.Name,
                Repeticao = model.Repeticao,
                Series = model.Series,

            };

            _repository.Create(exercicio);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Exercicio " + exercicio.Name + " foi adicionado com sucesso!"
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var exercicioList = await _repository.GetAllAsync();

            List<ExercicioDTO> exerciciosDTO = new List<ExercicioDTO>();

            foreach (Exercicio exercicio in exercicioList)
            {
                var exercicioDTO = new ExercicioDTO()
                {
                    Name = exercicio.Name,
                    Repeticao = exercicio.Repeticao,
                    Series = exercicio.Series,

                };

                exerciciosDTO.Add(exercicioDTO);
            }

            return Ok(exerciciosDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] Exercicio exercicio)
        {
            var e = _repository.GetByIdAsync(id);

            await _unitOfWork.CommitAsync();

            if (e == null)
            {
                return Ok(new
                {
                    message = "exercicio nao encontrado!!!  "
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
            var exercicio = await _repository.GetByIdAsync(id);

            if (exercicio == null)
                return NotFound();
            else
            {
                var exercicioDTO = new ExercicioDTO()
                {
                    Name = exercicio.Name,
                    Repeticao = exercicio.Repeticao,
                    Series = exercicio.Series,
                };
                return Ok(exercicioDTO);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateExercicioViewModel model)
        {
            
            var exercicio = await _repository.GetByIdAsync(id);
            if (exercicio == null) return NotFound();

            exercicio.Name = model.Name;
            exercicio.Repeticao = model.Repeticao;
            exercicio.Series = model.Series;

            _repository.Update(exercicio);
            await _unitOfWork.CommitAsync();
            return Ok(exercicio);
        }

    }
}