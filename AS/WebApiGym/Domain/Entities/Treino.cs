namespace Domain.Entities
{
    public class Treino
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exercicio Exercicio { get; set; }
        public Instrutor Instrutor { get; set; }
    }
}