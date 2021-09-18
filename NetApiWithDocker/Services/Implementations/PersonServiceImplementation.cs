﻿using NetApiWithDocker.Model;
using NetApiWithDocker.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetApiWithDocker.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context ; //Criando uma instância da classe contexto para ser injetada nesta classe

        public PersonServiceImplementation( MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges(); //Métodos da classe context injetada
            }
            catch (Exception)
            {

                throw ;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {


                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges(); //Métodos da classe context injetada
                }
                catch (Exception)
                {

                    throw;
                }


            }
        

        }

        public List<Person> FindAll()
        {
           
            return _context.Persons.ToList();
        }

   

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id)); //método da classe context injetada
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
          
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {

            
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges(); //Métodos da classe context injetada
                }
                catch (Exception)
                {

                    throw;
                }

                
            }
            return person;
        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id)); //O método Any retorna um valor booleano
        }
    }
}
