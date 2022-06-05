namespace CrudCobrancas.Models.Repository
{
    public interface IBaseRepository<Entity>
    where Entity : class
    {
        Entity GetById(int id);
         List<Entity>GetAll();
         void Create(Entity entity);
         void Update(Entity entity,int id);
         void Delete(int id);
         
    }
}