using System;


namespace Aula_06.DOMAIN
{
    
    public class Conta
    {
        public Conta( int idCliente,int idConta, DateTime dataEmissao, DateTime dataVenc, decimal valor)
        {
            IdCliente = idCliente;
            IdConta = idConta;
            DataEmissao = dataEmissao;
            DataVenc = dataVenc;
            Valor = valor;
            
        }
        public Conta ( int idCliente,int idConta,DateTime dataPag)
        {
            IdCliente = idCliente;
            IdConta = idConta;
            DataPag = dataPag;

        }
        
         public int IdCliente;
        public int IdConta { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVenc { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPag  { get; set; }
       
        public Cliente cliente  { get; set; }

    }
       
}
       