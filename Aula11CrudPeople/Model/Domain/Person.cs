namespace Aula11CrudPeople.Model.Domain
{
    public class Person
    {
        public Person(){}
        public Person(int id, string nome, string fone)
        {
            Id = id;
            Nome = nome;
            this.fone = fone;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string fone { get; set; }
    }
}