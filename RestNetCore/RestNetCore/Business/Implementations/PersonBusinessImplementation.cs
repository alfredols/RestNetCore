using RestNetCore.Model;
using RestNetCore.Model.Context;
using RestNetCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNetCore.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness

    {
        private readonly IPersonRepository _repository;
        public PersonBusinessImplementation(IPersonRepository repository) {
            _repository = repository;
        }
        
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            
            return _repository.Create(person);
        }
      
        public Person Update(Person person)
        {

            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
        
    }
}
