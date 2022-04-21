using System;
using System.Text;
using Aula_06.DATA;
using Aula_06.DOMAIN;


namespace Aula_06.SERVICES
{
    public class ContaServices
    {
        ContaRepository cobrancas = new ContaRepository();
        

         public  bool Validar( int idCliente )
        {
            return cobrancas.ValidationConta(idCliente);
        }

        public int TamanholistaConta()
        {
           return cobrancas.GetAllConta().Count ;
        }

        public string CreateConta(int idCliente,int id ,DateTime dataEmissao, DateTime dataVenc, decimal valor)
        {
            var valida =  Validar(idCliente);
           

            if(valida != true)
            {
                cobrancas.SaveConta(new Conta(idCliente,id,dataEmissao,dataVenc,valor));
             
            }
            else
            {
                return "Cliente não encontrado";
            }

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
                    builder.AppendLine($" Id : {conta.IdCliente} ClienteId: {conta.Id} Data Emissão :{conta.DataEmissao} Data Vencimento : {conta.DataVenc}Valor :{conta.Valor} Data de pagamento : {conta.DataPag}" );
                }

            }
            return builder.ToString();
        }

        public string RemoveConta(int idConta)
        {
            var valido = Validar(idConta);
            
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
         public string BuscarConta(int idCliente)
        {
            var builder = new StringBuilder();
            var listaContas = cobrancas.GetAllConta();
            var valida =  Validar(idCliente);

             if (valida == true)
            {
                foreach(Conta conta in listaContas)
                {
                    if(idCliente == conta.IdCliente)
                    {
                        builder.AppendLine($" (Id): {conta.Id} (Data Emissão) :{conta.DataEmissao} (Data Vencimento) : {conta.DataVenc} (Valor ):{conta.Valor} (Data de pagamento) : {conta.DataPag}" );
                    }
                }

            }
            else
            {
                return "Conta não encontrada";
            }
            return builder.ToString();   
        }
    }
}