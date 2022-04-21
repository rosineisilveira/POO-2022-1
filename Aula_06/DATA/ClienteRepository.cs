using System.Collections.Generic;
using System.Linq;
using Aula_06.DOMAIN;

namespace Aula_06.DATA
{
    public class ClienteRepository
    {
        private List<Cliente>ListaDeClientes = new List<Cliente>();
        //private List<Conta>contaCliente = new List<Conta>();

        public List<Cliente> GetAllCliente()
        {
            return ListaDeClientes;
        }

        public void SaveCliente(Cliente cliente)
        {
            ListaDeClientes.Add(cliente);
        }

        public Cliente GetByIdCliente(int idCliente)
        {
            
            return ListaDeClientes.Find(p => p.Id == idCliente );    

        }
        
        public void UpdateCliente(Cliente cliente)
        {
           
            var clienteEdit =  GetByIdCliente(cliente.Id);
           
            clienteEdit.Fone = cliente.Fone;
            clienteEdit.Nome = cliente.Nome;
                
        }

        public void DeleteCliente(int idCliente)
        {
             
            var remover = GetByIdCliente(idCliente);
            ListaDeClientes.Remove(remover);
            
        }
        public bool ValidationCliente(int idCliente)
        {
             return ListaDeClientes.Any(p => p.Id ==idCliente );
        }
       



      
    }
}