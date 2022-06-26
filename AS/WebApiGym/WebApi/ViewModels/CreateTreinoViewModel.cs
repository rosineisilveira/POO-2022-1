using Domain.Entities;

namespace WebApi.ViewModels
{
    public class CreateTreinoViewModel
    {
        public string Name { get; set; }
        public Exercicio Exercicio { get; set; }
        public Instrutor Instrutor { get; set; }
    }
}