using System.Collections;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly DataContext Context;
        public ExercicioRepository(DataContext context)
        {
            this.Context = context;
        }

        public void Create(Exercicio exercicio)
        {
            Context.Add(exercicio);
        }

        public void Delete(int exercicioId)
        {
            var exercicio =  GetByIdAsync(exercicioId);
            Context.Remove(exercicio);
        }

        public async Task<Exercicio> GetByIdAsync(int exercicioId)
        {
            return await Context.DbSetExercicio.
            SingleOrDefaultAsync(i =>i.Id == exercicioId);
        }


        public void Update(Exercicio exercicio)
        {
            Context.Entry(exercicio).State = EntityState.Modified;
        }

        public async Task<List<Exercicio>> GetAllAsync()
        {
            return await Context.DbSetExercicio.ToListAsync();
        }
    }
}