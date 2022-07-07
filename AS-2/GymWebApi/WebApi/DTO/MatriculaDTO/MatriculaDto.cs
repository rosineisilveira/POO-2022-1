using Domain.Entities;

namespace WebApi.DTO.MatriculaDTO
{
    public class MatriculaDto
    {
        public DateTime  DataCadastro { get; set; }
        public bool Status { get; set; }

        public Aluno Aluno { get; set; }

        public Plano Plano { get; set; }
        
        public Pagamento Pagamento { get; set; }

        public int TreinoId { get; set; }

       public IList<Treino> Treinos { get; set; }
    }
}