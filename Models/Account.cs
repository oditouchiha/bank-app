// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.ObjectModel;

namespace BankApp.Models;

public class Account : Auditable
{
    public Account()
    {
        AccountLotteries = new Collection<AccountLottery>();
    }

    public int AccountId { get; set; }
    public decimal Balance { get; set; }
    public string? Number { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<Transaction>? DepositTransactions { get; set; }
    public ICollection<Transaction>? WithdrawTransactions { get; set; }

    public ICollection<AccountLottery> AccountLotteries { get; set; }
}
