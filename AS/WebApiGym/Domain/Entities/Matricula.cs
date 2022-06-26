namespace Domain.Entities
{
    public class Matricula
    {
        public Matricula(){}
        public int Id { get; set; }
        public DateTime  DataCadastro { get; set; }
        public Aluno Aluno { get; set; }
        public Planos Mensalidade { get; set; }
        public Treino Treino { get; set; }
        public bool Status { get; set; }
    }
}