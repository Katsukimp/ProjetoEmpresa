using HiringTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Domain.Interfaces
{
    public interface IBankRepository
    {
        Bank Get(int id);
        IEnumerable<Bank> GetAll();
        void Insert(Bank bank);
        void Update(Bank bank);
        void Delete(int id);
    }
}
