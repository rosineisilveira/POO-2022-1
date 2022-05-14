using System.Collections.Generic;
using CobrancasApi.Models.Domain;

namespace CobrancasApi.Models.Repositores
{
    public interface IClienteRepository
    {
         Cliente GetById(int id);
         List<Cliente>GetALL();
         void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);

    }
}