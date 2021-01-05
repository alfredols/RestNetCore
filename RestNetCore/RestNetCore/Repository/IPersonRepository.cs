using RestNetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNetCore.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);        
        List<Person> FindAll();
        void Delete(long id);
        bool Exists(long? id);

    }
}
