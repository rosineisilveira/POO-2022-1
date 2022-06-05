using CrudCobrancas.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace CrudCobrancas.Models.Repository
{
    public class DataContext : DbContext
    {
        //public DataContext(){}
        public DataContext(DbContextOptions<DataContext> opts)
            :base(opts)
        {}
        
        public DbSet<Client>Customers { get; set; } 
        public DbSet<Charge>Charges { get; set; } 
        
    }
}
