using System.Collections;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PlanosRepository : IPlanosRepository
    {
        private readonly DataContext Context;
        public PlanosRepository(DataContext context)
        {
            this.Context = context;
        }

        public void Create(Planos planos)
        {
            Context.Add(planos);
        }

        public void Delete(int planosId)
        {
            var planos =  GetByIdAsync(planosId);
            Context.Remove(planos);
        }

        public async Task<Planos> GetByIdAsync(int planosId)
        {
            return await Context.DbSetPlanos.
            SingleOrDefaultAsync(i =>i.Id == planosId); 
                
        }

        public void Update(Planos planos)
        {
            Context.Entry(planos).State = EntityState.Modified;
        }

        public async Task<List<Planos>> GetAllAsync()
        {
            return await Context.DbSetPlanos.ToListAsync();
        }
    }
}