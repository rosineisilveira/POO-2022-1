using System.Collections.Generic;
using Aula11CrudPeople.Model.Domain;

namespace Aula11CrudPeople.Model.Repositories
{
    public interface IPersonRepository
    {
        Person GetById(int Id);
        List<Person>GetALL();

        void Create(Person person);
        void Update(Person person);
        void Delete(int id);
    }
}