using System;
using System.Text;
using Aula_06.DATA;
using Aula_06.DOMAIN;

namespace Aula_06.SERVICES
{
    public class CobrancaServices
    {
        CobrancaRepository financeiro = new CobrancaRepository();

        public  bool Validar( int idCliente )
        {
            return financeiro.ValidationCliente(idCliente);
        }

        public int TamanholistaCliente()
        {
           return financeiro.GetAllCliente().Count ;
        }
       

        public string CreateCliente(int id ,string nome,string fone)
        {

            financeiro.SaveCliente(new Cliente(id,nome,fone));

            return "Add com sucesso";   
        }

        public string ListClientes()
        {
            var builder = new StringBuilder();
            var listaClientes = financeiro.GetAllCliente();
            var qtdClientes = TamanholistaCliente();

            if ( qtdClientes == 0)
            {
                Console.WriteLine("Lista vazia");
            }
            else
            {
                foreach(Cliente cliente in listaClientes)
                {
                    builder.AppendLine($"nome:{cliente.Nome} Telefone: {cliente.Fone} Id :{cliente.Id}");
                }

            }
            return builder.ToString();
        }
        public string RemoveCliente(int idCliente)
        {
            var valido = Validar(idCliente);
            
            var qtdClientes = TamanholistaCliente();

            if ( qtdClientes == 0)
            {
                Console.WriteLine("Lista vazia");
            }
            else if(valido == true)
            {
                financeiro.DeleteCliente(idCliente);
            }
            else
            {
                return "Cliente não encontrado";
            }
            return "Removido com sucesso";  

        }

        public string AtualizarCliente(int idCliente,String nome,string fone )
        {

            var valida =  Validar(idCliente);
           

            if(valida == true)
            {
                financeiro.UpdateCliente(new Cliente(idCliente,nome,fone));                    
            }
            else
            {
                return "Cliente não encontrado";
            }
       
            return "Atualizado com sucesso";
           

        }
        public string BuscarCliente(int idCliente)
        {
            var builder = new StringBuilder();
            var listaClientes = financeiro.GetAllCliente();
            var valida =  Validar(idCliente);

             if (valida == true)
            {
                foreach(Cliente cliente in listaClientes)
                {
                    if(idCliente == cliente.Id)
                    {
                     builder.AppendLine($"nome:{cliente.Nome} Telefone: {cliente.Fone} Id :{cliente.Id}");   
                    }
                }

            }
            else
            {
                return "Cliente nao encontrado";
            }
            return builder.ToString();
        }
        

    }


}