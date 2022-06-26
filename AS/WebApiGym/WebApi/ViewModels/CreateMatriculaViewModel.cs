using Domain.Entities;

namespace WebApi.ViewModels
{
    public class CreateMatriculaViewModel
    {
        public DateTime  DataCadastro { get; set; }
        public Aluno Aluno { get; set; }
        public Planos Mensalidade { get; set; }
        public Treino Treino { get; set; }
        public bool Status { get; set; } 
    }
}