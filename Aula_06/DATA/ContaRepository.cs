using System.Collections.Generic;
using System.Linq;
using Aula_06.DOMAIN;


namespace Aula_06.DATA
{
    public class ContaRepository
    {
         private List<Conta> Contas = new List<Conta>();
         private List<Cliente> ContasClientes = new List<Cliente>();

         public List<Conta> GetAllConta()
        {
            return Contas;
        }
        public void SaveConta(Conta conta)
        {
            Contas.Add(conta);
        }
        public Conta GetByIdConta(int idConta)
        {
            
            return Contas.Find(p => p.Id == idConta );    

        }
        public Conta GetByIdContaCliente(int idCliente)
        {
            
            return Contas.Find(p => p.Id == idCliente );    

        }
         public void UpdateConta(Conta conta)
        {
           
            var contaEdit =  GetByIdConta(conta.IdCliente);
           
            contaEdit.DataPag = conta.DataPag;
            
                
        }
         public void DeleteConta(int idConta)
        {
             
            var remover = GetByIdConta(idConta);
            Contas.Remove(remover);
            
        }
         public bool ValidationConta(int idCliente)
        {
             return ContasClientes.Any(p => p.Id ==idCliente );
        }
        

    }

    
}