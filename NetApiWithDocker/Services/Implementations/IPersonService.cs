﻿using NetApiWithDocker.Model;
using System.Collections.Generic;

namespace NetApiWithDocker.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long Id);
    }
}
