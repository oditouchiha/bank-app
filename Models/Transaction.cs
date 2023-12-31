// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Models;

public class Transaction : Auditable
{
    public int TransactionId { get; set; }
    public DateTime Timestamp { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }

    public int DepositorAccountId { get; set; }
    public Account? DepositorAccount { get; set; }
    public int WithdrawlAccountId { get; set; }
    public Account? WithdrawlAccount { get; set; }
}
