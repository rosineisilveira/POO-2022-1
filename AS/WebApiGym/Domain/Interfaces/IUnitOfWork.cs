namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        IAlunoRepository AlunoRepository {get;}
    }
}