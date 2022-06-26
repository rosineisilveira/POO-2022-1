using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly DataContext _Context;

        public UnitOfWork(DataContext context)
        {
            this._Context = context;
        }

        public  async Task CommitAsync()
        {
            await _Context.SaveChangesAsync();
            
        }
        private IAlunoRepository _AlunoRepository;
       
        public IAlunoRepository AlunoRepository
        {
            get { return _AlunoRepository ??= new AlunoRepository(_Context);}
        }
         private IInstrutorRepository _InstrutorRepository;

        public IInstrutorRepository InstrutorRepository
        {
            get { return _InstrutorRepository ??= new InstrutorRepository(_Context);}
        }

        private IPlanosRepository _PlanosRepository;

         public IPlanosRepository PlanosRepository
        {
            get { return _PlanosRepository ??= new PlanosRepository(_Context);}
        }

       
    }
}