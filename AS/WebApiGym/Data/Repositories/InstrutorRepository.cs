using System.Collections;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class InstrutorRepository : IInstrutorRepository
    {

        private readonly DataContext Context;
        public InstrutorRepository(DataContext context)
        {
            this.Context = context;
        }

        public void Create(Instrutor instrutor)
        {
             Context.Add(instrutor);
        }

        public void Delete(int instrutorId)
        {
            var instrutor =  GetByIdAsync(instrutorId);
            Context.Remove(instrutor);
        }


        public async Task<Instrutor> GetByIdAsync(int instrutorId)
        {
            return await Context.DbSetInstrutor.
            SingleOrDefaultAsync(i =>i.Id == instrutorId);
        }

        public void Update(Instrutor instrutor)
        {
            Context.Entry(instrutor).State = EntityState.Modified;
        }

        public async Task<List<Instrutor>>GetAllAsync()
        {
            return await Context.DbSetInstrutor.ToListAsync();
        }
    }
}