using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TreinoController : ControllerBase
    {
        private readonly ITreinoRepository repository;

        public TreinoController(ITreinoRepository repository)
        {
            this.repository = repository;
        }
    }
}