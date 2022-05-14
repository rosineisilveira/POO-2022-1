using System.Collections.Generic;
using System.Linq;
using CobrancasApi.Models.Domain;
using CobrancasApi.Models.Repositores;

namespace CobrancasApi.Models.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private DataContext context;

        public ClienteRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(Cliente cliente)
        {
           context.Add(cliente);
           context.SaveChanges();
        }

        public void Delete(int id)
        {
           context.Remove(id);
        }

        public List<Cliente> GetALL()
        {
           return context.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return context.Clientes.SingleOrDefault(i=>i.Id == id);
        }

        public void Update(Cliente cliente)
        {
            var c =  GetById(cliente.Id);
           
            c.Fone = cliente.Fone;
            c.Nome = cliente.Nome;
            
        }
    }
}