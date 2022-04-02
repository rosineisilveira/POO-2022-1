using System.Collections.Generic;

namespace aula_revisao
{
    public class AddContato
    {
        public AddContato(int idContatos, List<Pessoa> pessoas)
        {
            IdContatos = idContatos;
            Pessoas = pessoas;
        }

        public int IdContatos { get; set; }
        public List< Pessoa> Pessoas { get; set; }
    }
}