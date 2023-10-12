// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Configurations;

public class AccountLotteryConfiguration : IEntityTypeConfiguration<AccountLottery>
{
    public void Configure(EntityTypeBuilder<AccountLottery> builder)
    {
        builder
            .HasKey(ap => new { ap.AccountId, ap.LotteryId });

        builder
            .HasOne(ap => ap.Account)
            .WithMany(a => a.AccountLotteries)
            .HasForeignKey(ap => ap.AccountId);

        builder
            .HasOne(ap => ap.Lottery)
            .WithMany(p => p.AccountLotteries)
            .HasForeignKey(ap => ap.LotteryId);
    }
}
