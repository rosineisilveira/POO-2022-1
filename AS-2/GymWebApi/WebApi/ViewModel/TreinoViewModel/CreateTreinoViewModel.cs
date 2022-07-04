using Domain.Entities;

namespace WebApi.ViewModel.TreinoViewModel
{
    public class CreateTreinoViewModel
    {
        public string Nome { get; set; }

        //public Instrutor Instrutor { get; set; }
        public int InstrutorId { get; set; }
        public int ExercicioId { get; set; }

        //public IList<Exercicio> Exercicios { get; set; }
    }
}