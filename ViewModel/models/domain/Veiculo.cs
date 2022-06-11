namespace ViewModel.models.domain
{
    public class Veiculo
    {
        public Veiculo(int id, string nome, DateTime anoFabricacao)
        {
            Id = id;
            Nome = nome;
            AnoFabricacao = anoFabricacao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime AnoFabricacao{ get; set; }
    }
}