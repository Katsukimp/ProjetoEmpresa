using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringTest.Domain.Entities;
using HiringTest.Infrastructure.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;


namespace HiringTest.Infrastructure.Data.Common
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options)
               : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<LogAccount> LogAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new BankMap());
            modelBuilder.ApplyConfiguration(new LogAccountMap());
        }
    }
}
