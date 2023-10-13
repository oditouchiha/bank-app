// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Models;
using BankApp.Services.Lotteries;
using Microsoft.EntityFrameworkCore;

namespace BankApp;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Lottery> Lotteries { get; set; }
    public DbSet<AccountLottery> AccountsLotteries { get; set; }
    public DbSet<LotteryTotalSpendingResponse> lotteryTotalSpendingResponses { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Auditable>();
        modelBuilder.Entity<LotteryTotalSpendingResponse>().HasNoKey();

        foreach (var et in modelBuilder.Model.GetEntityTypes())
        {
            if (et.ClrType.IsSubclassOf(typeof(Auditable)))
            {
                et.FindProperty("Created").SetDefaultValueSql("getdate()");
                et.FindProperty("Created").ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;

                et.FindProperty("LastModified").SetDefaultValueSql("getdate()");
                et.FindProperty("LastModified").ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAddOrUpdate;
            }

        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
