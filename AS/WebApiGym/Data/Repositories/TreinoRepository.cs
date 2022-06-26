using System.Collections;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly DataContext Context;
        public TreinoRepository(DataContext context)
        {
            this.Context = context;
        }

        public void Create(Treino entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Treino> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Treino entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Treino>> IBaseRepository<Treino>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}