namespace ViewModel.models.repository
{
    public interface IBaseRepository<Entity>
    where Entity : class
    {
         Task<Entity> GetByIdAsinc(int id);
         Task<List<Entity>>GetAllAsinc();
         void Create(Entity entity);
         void Update(Entity entity,int id);
         void Delete(int id);
         
    }
}