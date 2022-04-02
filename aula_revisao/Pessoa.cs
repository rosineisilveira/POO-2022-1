using System.Collections.Generic;

namespace aula_revisao
{
    public class Pessoa
    {
        
        public string Numero { get; private set; }
        public string Nome { get; private set; }

        public Pessoa(string numero, string nome)
        {
            this.Numero = numero;
            this.Nome = nome;
        }
        
    }
}