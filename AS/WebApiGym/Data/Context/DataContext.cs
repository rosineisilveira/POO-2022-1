using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options)
         : base(options)
        {}
         public DbSet<Aluno>DbSetAluno { get; set; } 
         public DbSet<Exercicio>DbSetExercicio { get; set; }
         public DbSet<Instrutor>DbSetInstrutor { get; set; }
         public DbSet<Matricula>DbSetMatricula { get; set; }
         public DbSet<Planos>DbSetPlanos { get; set; }
         public DbSet<Treino>DbSetTreino { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new InstrutorMap());
            //modelBuilder.ApplyConfiguration(new ExercicioMap());
            //modelBuilder.ApplyConfiguration(new MatriculaMap());
            modelBuilder.ApplyConfiguration(new PlanosMap());
            //modelBuilder.ApplyConfiguration(new TreinoMap());
         }
    }
}