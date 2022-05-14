using Aula11CrudPeople.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aula11CrudPeople.Model.Repositories
{
    public class DataContext : DbContext
    {
    
        public DataContext(DbContextOptions<DataContext>opts)

             :base(opts)
        {}
        public DbSet<Person> People { get; set; }
    }
}