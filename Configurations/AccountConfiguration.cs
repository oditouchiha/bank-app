using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasOne(a => a.Customer)
                .WithOne(c => c.Account)
                .HasForeignKey<Account>(a => a.CustomerId);

            builder
                .HasMany(a => a.DepositTransactions)
                .WithOne(t => t.DepositorAccount)
                .HasForeignKey(t => t.DepositorAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(a => a.WithdrawTransactions)
                .WithOne(t => t.WithdrawlAccount)
                .HasForeignKey(t => t.WithdrawlAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}