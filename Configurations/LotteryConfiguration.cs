// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Configurations;

public class LotteryConfiguration : IEntityTypeConfiguration<Lottery>
{
    public void Configure(EntityTypeBuilder<Lottery> builder)
    {
        builder
            .HasMany(p => p.AccountLotteries)
            .WithOne(al => al.Lottery)
            .HasForeignKey(ap => ap.LotteryId);
    }
}
