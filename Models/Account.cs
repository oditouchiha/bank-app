// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.ObjectModel;

namespace BankApp.Models;

public class Account : Auditable
{
    public Account()
    {
        AccountPortofolios = new Collection<AccountPortofolio>();
    }

    public int AccountId { get; set; }
    public decimal Balance { get; set; }
    public string Number { get; set; } = null!;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public ICollection<Transaction>? DepositTransactions { get; set; }
    public ICollection<Transaction>? WithdrawTransactions { get; set; }

    public ICollection<AccountPortofolio> AccountPortofolios { get; set; }
}
