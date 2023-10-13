// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Services.Lotteries;

public class LotteryTotalSpendingResponse
{
    public int accountId { get; set; }
    public string? name { get; set; }
    public decimal totalSpending { get; set; }
}
