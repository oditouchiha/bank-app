// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Services.Lotteries;

public class LotteryCreateSchema
{
    public required string name { get; set; }
    public decimal price { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
}
