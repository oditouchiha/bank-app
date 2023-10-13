// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using AutoFixture;
using BankApp.Models;

namespace BankApp;

public static class Seeder
{
    public static void Seed(this DatabaseContext databaseContext)
    {
        if (!databaseContext.Customers.Any())
        {
            var fixture = new Fixture();

            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize<Customer>(c => c
                .Without(c => c.CustomerId)
                .Without(c => c.Account)
            );

            var customers = fixture.CreateMany<Customer>(10).ToList();

            foreach (var customer in customers)
            {
                var account = fixture.Build<Account>()
                    .Without(acc => acc.AccountId)
                    .Without(acc => acc.AccountLotteries)
                    .Without(acc => acc.DepositTransactions)
                    .Without(acc => acc.WithdrawTransactions)
                    .With(acc => acc.Customer, customer)
                    .Create();

                customer.Account = account;
            }

            databaseContext.AddRange(customers);

            databaseContext.SaveChanges();
        }
    }
}
