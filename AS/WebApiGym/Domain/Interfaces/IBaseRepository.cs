using System.Collections;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
         Task<Entity> GetByIdAsync(int entityId);
         Task<List<Entity>> GetAllAsync();
         void Create(Entity entity);
         void Delete(int entityId);
         void Update(Entity entity);
    }
}