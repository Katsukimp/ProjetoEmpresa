using HiringTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Infrastructure.Data.EntityConfig
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.AccountNumber)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(m => m.PreviousBalance)
                .IsRequired();
            builder.Property(m => m.TotalCredit);
            builder.Property(m => m.TotalDebt);
            builder.Property(m => m.FinalBalance);
            builder.HasOne(m => m.Bank)
                .WithMany()
                .HasForeignKey(m => m.IdBank); 
            builder.HasOne(m => m.Person)
                 .WithMany()
                 .HasForeignKey(m => m.IdPerson);
        }
    }
}
