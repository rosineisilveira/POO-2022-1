using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepository repository;

        public MatriculaController(IMatriculaRepository repository)
        {
            this.repository = repository;
        }
    }
}