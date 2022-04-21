using System;


namespace Aula_06.DOMAIN
{
    
    public class Conta
    {
        public Conta( int idCliente, int id,DateTime dataEmissao, DateTime dataVenc, decimal valor)
        {
            IdCliente = idCliente;
            Id = id;
            DataEmissao = dataEmissao;
            DataVenc = dataVenc;
            Valor = valor;
            
        }
        public Conta ( int idCliente,int id,DateTime dataPag)
        {
            IdCliente = idCliente;
            Id = id;
            DataPag = dataPag;

        }
        
         public int IdCliente;
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVenc { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPag  { get; set; }
       
        public Cliente cliente  { get; set; }

    }
       
}
       