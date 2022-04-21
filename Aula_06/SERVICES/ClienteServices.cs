using System;
using System.Text;
using Aula_06.DATA;
using Aula_06.DOMAIN;

namespace Aula_06.SERVICES
{
    public class ClienteServices
    {
        ClienteRepository consumidor = new ClienteRepository();
        

        public  bool Validar( int idCliente )
        {
            return consumidor.ValidationCliente(idCliente);
        }

        public int TamanholistaCliente()
        {
           return consumidor.GetAllCliente().Count ;
        }
       

        public string CreateCliente(int id ,string nome,string fone)
        {
            var validando = consumidor.ValidationCliente(id);
            
                {
                    if(validando == false)
                    {
                       consumidor.SaveCliente(new Cliente(id,nome,fone));

                    }
                    else
                    {
                        return " ID já utilizado,tente outro !!!";
                    }
                }

           

            return "Add com sucesso";   
        }

        public string ListClientes()
        {
            var builder = new StringBuilder();
            var listaClientes = consumidor.GetAllCliente();
            var qtdClientes = TamanholistaCliente();

            if ( qtdClientes == 0)
            {
                Console.WriteLine("Lista vazia");
            }
            else
            {
                foreach(Cliente cliente in listaClientes)
                {
                    builder.AppendLine($"(nome):{cliente.Nome} (Telefone): {cliente.Fone} (Id) :{cliente.Id}");
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
                consumidor.DeleteCliente(idCliente);
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
                consumidor.UpdateCliente(new Cliente(idCliente,nome,fone));                    
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
            var listaClientes = consumidor.GetAllCliente();
            var valida =  Validar(idCliente);

             if (valida == true)
            {
                foreach(Cliente cliente in listaClientes)
                {
                    if(idCliente == cliente.Id)
                    {
                     builder.AppendLine($"(Nome):{cliente.Nome} (Telefone): {cliente.Fone} (Id ):{cliente.Id}");   
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