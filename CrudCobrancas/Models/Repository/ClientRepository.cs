using CrudCobrancas.Models.Domain;


namespace CrudCobrancas.Models.Repository
{
    public class ClientRepository : IClientRepository
    {
        private DataContext context;

        public ClientRepository(DataContext context)
        {
            this.context = context;
        }
         public void Create(Client client)
        {
           context.Add(client);
           context.SaveChanges();
        }

        public void Delete(int id)
        {
           var c =  GetById(id);
           context.Remove(c);
           context.SaveChanges();

        }

        public List<Client> GetAll()
        {
            return context.Customers.ToList();
            
        }

        public Client GetById(int id)
        {
            return context.Customers.SingleOrDefault(i =>i.Id.Equals(id));
        }

       

        public void Update(Client client, int id)
        {
             var c =  GetById( id);
           
            c.Fone = client.Fone;
            c.Nome = client.Nome;
            context.SaveChanges();
        } 

    }   
    
}