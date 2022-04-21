using System.Collections.Generic;

namespace Aula_06.DOMAIN


{
    public class Cliente
    {

        public Cliente(int id, string nome, string fone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Fone = fone;
            this.Contas = new List<Conta>();

        }
        public int Id { get; set; }  
        public string Nome { get; set; }
        public string Fone { get; set; }
        public List<Conta> Contas { get; set; }

        
       

        

    }
     


}