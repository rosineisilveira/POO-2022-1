using System.Collections;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository

    {
        private readonly DataContext Context;
        public MatriculaRepository(DataContext context)
        {
            this.Context = context;
        }

        public void Create(Matricula entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }
        
        public Task<Matricula> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Matricula entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Matricula>> IBaseRepository<Matricula>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}