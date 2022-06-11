using Microsoft.EntityFrameworkCore;
using ViewModel.models.domain;

namespace ViewModel.models.repository
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> opts)
            :base(opts)
        {}
        
        public DbSet<Veiculo>Veiculos { get; set; } 
        
    }
}