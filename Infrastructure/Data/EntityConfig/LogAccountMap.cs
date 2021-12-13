using HiringTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Infrastructure.Data.EntityConfig
{
    public class LogAccountMap : IEntityTypeConfiguration<LogAccount>
    {
        public void Configure(EntityTypeBuilder<LogAccount> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(m => m.EntryDate)
                .IsRequired();
            builder.HasOne(m => m.Account)
                .WithMany()
                .HasForeignKey(m => m.IdAccount);
        }
    }
}
