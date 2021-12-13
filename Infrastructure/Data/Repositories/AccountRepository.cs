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
    public class AccountRepository : EfRepository<Account>, IAccountRepository
    {
        public AccountRepository(RegisterContext dbContext)
            : base(dbContext)
        {
        }

    }
}
