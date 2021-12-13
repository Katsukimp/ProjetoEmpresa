using HiringTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Domain.Interfaces
{
    public interface ILogAccountRepository
    {
        LogAccount Get(int id);
        IEnumerable<LogAccount> GetAll();
        IEnumerable<LogAccount> GetByDate(DateTime time);
        void Insert(LogAccount logAccount);
        void Update(LogAccount logAccount);
        void Delete(int id);
    }
}
