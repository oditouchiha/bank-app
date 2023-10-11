// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Configurations;

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
