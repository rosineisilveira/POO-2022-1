using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aula_06.DATA;
using Aula_06.DOMAIN;


namespace Aula_06.SERVICES
{
    public class ContaServices
    {
        ContaRepository cobrancas = new ContaRepository();
        ClienteRepository consumidor = new ClienteRepository();
        
        
         public  bool Validar( int idCliente )
        {
            return cobrancas.ValidationConta(idCliente);
        }

        public int TamanholistaConta()
        {
           return cobrancas.GetAllConta().Count ;
        }

        public string CreateConta(int idCliente,int idConta, DateTime dataEmissao, DateTime dataVenc, decimal valor)
        {    
               
            cobrancas.SaveConta(new Conta(idCliente,idConta,dataEmissao,dataVenc,valor));
                    
            return "Add com sucesso";   
        }
        public string ListContas(int idCliente)
        {
            var builder = new StringBuilder();
            var listaContas = cobrancas.GetAllConta();
            var qtdContas = TamanholistaConta();

           if ( qtdContas == 0)
            {
                Console.WriteLine("Lista vazia");
            }
            else
            {
                foreach(Conta conta in listaContas)
                {
                     if(idCliente == conta.IdCliente)
                     {
                         builder.AppendLine($" (ClienteId) : {conta.IdCliente} (IdConta): {conta.IdConta} (Data Emissão) :{conta.DataEmissao} (Data Vencimento) : {conta.DataVenc} (Valor) :{conta.Valor} (Data de pagamento) : {conta.DataPag}" );
                     }
                     else
                     {
                         return "Lista de contas vazia";
                     }
                       
                }

            }
            return builder.ToString();
        }

        public string RemoveConta(int idCliente,int idConta)
        {
            var valido = Validar(idCliente);
            
            var qtdContas = TamanholistaConta();

            if ( qtdContas == 0)
            {
                Console.WriteLine("Lista vazia");
            }
            else if(valido == true)
            {
                cobrancas.DeleteConta(idConta);   
            }
            else
            {
                return "Conta não encontrado";
            }
            return "Removido com sucesso";  

        }
        public string AtualizarConta(int idCliente, int idConta,DateTime dataPag )
        {
            var valida =  Validar(idCliente);
            if(valida == true)
            {
                cobrancas.UpdateConta(new Conta(idCliente,idConta,dataPag));                    
            }
            else
            {
                return "Cliente não encontrado";
            }
       
            return "Atualizado com sucesso";
        }
        
    }
}