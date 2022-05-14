namespace CobrancasApi.Models.Domain
{
    public class Cliente
    {
        public Cliente(int id, string nome, string fone)
        {
            Id = id;
            Nome = nome;
            Fone = fone;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
    }
}