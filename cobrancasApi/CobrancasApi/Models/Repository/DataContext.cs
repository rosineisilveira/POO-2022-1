using CobrancasApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CobrancasApi.Models.Repositores
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext>opts)

             :base(opts)
        {}
        public DbSet<Cliente> Clientes { get; set; }
        
    }
}