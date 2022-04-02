using System;
using System.Collections.Generic;

//FOI O QUE CONSEGUI ANTES DA ULTMA AULA 

namespace aula_revisao
{
    class Program
    { 
        static AddContato adicionar;
          
        static void Main(string[] args)
        {
        Pessoa pessoa = new Pessoa("9999999999","rosinei");
        Pessoa pessoa2 = new Pessoa("589621458","carine");
        Pessoa pessoa3 = new Pessoa("487562133","chico");

           // Console.WriteLine(pessoa.Nome);
            //Console.WriteLine(pessoa.Numero);
        
        adicionar = new AddContato(1,
            new List<Pessoa>()
            {
                pessoa,
                pessoa2,
                pessoa3
            });

            ImprimirAgenda();

        }

        public static void ImprimirAgenda()
        {
            foreach (var item in adicionar.Pessoas)
            {
                Console.WriteLine(item.Nome);
                Console.WriteLine(item.Numero);
            }
        }
    }
}
