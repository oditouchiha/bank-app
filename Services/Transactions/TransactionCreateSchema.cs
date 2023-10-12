// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Services.Transactions;

public class TransactionCreateSchema
{
    public decimal amount { get; set; }
    public required string currency { get; set; }
    public required int depositorAccountId { get; set; }
    public required int withdrawlAccountId { get; set; }
}
