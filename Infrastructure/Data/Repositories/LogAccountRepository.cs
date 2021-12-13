using HiringTest.Domain.Entities;
using HiringTest.Domain.Interfaces;
using HiringTest.Infrastructure.Data.Common;
using HiringTest.Infrastructure.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Infrastructure.Data.Repositories
{
    public class LogAccountRepository : EfRepository<LogAccount>, ILogAccountRepository
    {
        public LogAccountRepository(RegisterContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<LogAccount> GetByDate(DateTime time)
        {
            return _dbContext.Set<LogAccount>().Where(a => a.EntryDate.Equals(time)).ToList();
        }
    }
}
