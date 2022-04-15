using System;

namespace Aula_06.DOMAIN
{
    public class Conta
    {
         
        public Conta( DateTime dataEmissao, DateTime dataVenc, decimal valor,DateTime dataPag, Cliente cliente)
        {
            
            DataEmissao = dataEmissao;
            DataVenc = dataVenc;
            DataPag = dataPag;
            Valor = valor;
            Cliente = cliente;
        }

        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVenc { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPag { get; set; }
        public Cliente  Cliente { get; set; }


    }    
    
}
       