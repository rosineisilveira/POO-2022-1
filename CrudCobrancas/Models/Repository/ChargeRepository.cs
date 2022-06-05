using CrudCobrancas.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudCobrancas.Models.Repository
{
    public class ChargeRepository : IChargeRepository
    {
        private DataContext context;
        public ChargeRepository(DataContext context)
        {
            this.context = context;
        }
        public void Create(Charge charge)
        {  
            charge.Client = context.Customers.
            SingleOrDefault(x=>x.Id == charge.Client.Id);
            context.Add(charge);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            
           var c =  GetById(id);
           context.Remove(c);
           context.SaveChanges();
        }

        public List<Charge> GetAll()
        {
             return context.Charges.Include(c => c.Client).ToList();
        }

        public Charge GetById(int id)
        {
              return context.Charges.Include(c=>c.Client).SingleOrDefault(x => x.Id == id);
        }

       

        public void Update(Charge charge, int id)
        {
            //atribuir data de pagamento
            var c =  GetById( id);
           
            c.DataPag = charge.DataPag;
            
            context.SaveChanges();
        }
    }
}