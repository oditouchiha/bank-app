using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Configurations
{
    public class TransactionConfiguration
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .HasOne(t => t.DepositorAccount)
                .WithMany(a => a.DepositTransactions)
                .HasForeignKey(t => t.DepositorAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.WithdrawlAccount)
                .WithMany(a => a.WithdrawTransactions)
                .HasForeignKey(t => t.WithdrawlAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}