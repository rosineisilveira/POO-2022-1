namespace Aula_06.DOMAIN
{
    public class Cliente
    {
        public Cliente(int id,string nome,string fone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Fone = fone;
        }
        

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }

    }
}