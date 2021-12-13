using HiringTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Account Get(int id);
        IEnumerable<Account> GetAll();
        void Insert(Account account);
        void Update(Account account);
        void Delete(int id);
    }
}
