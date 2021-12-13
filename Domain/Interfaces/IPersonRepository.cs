using HiringTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Person Get(int id);
        IEnumerable<Person> GetAll();
        void Insert(Person person);
        void Update(Person person);
        void Delete(int id);

    }
}
