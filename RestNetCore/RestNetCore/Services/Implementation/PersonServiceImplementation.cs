﻿using RestNetCore.Model;
using RestNetCore.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNetCore.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService

    {
        private readonly MySQLContext _context;
        public PersonServiceImplementation(MySQLContext context) {
            _context = context;

        }
        
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }
      
        public Person Update(Person person)
        {

            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(person.Id)) return null;

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Persons.SingleOrDefault(b => b.Id == person.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(i => i.Id == id);
            try
            {
                if (result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Exists(long? id)
        {
            return _context.Persons.Any(b => b.Id == id);
        }
    }
}
