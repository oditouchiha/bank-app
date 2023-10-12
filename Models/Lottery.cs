// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.ObjectModel;

namespace BankApp.Models;

public class Lottery : Auditable
{
    public Lottery()
    {
        AccountLotteries = new Collection<AccountLottery>();
    }

    public required string Name { get; set; }
    public int LotteryId { get; set; }
    public decimal PrizePool { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<AccountLottery> AccountLotteries { get; set; }
}
