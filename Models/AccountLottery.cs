// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Models;

public class AccountLottery
{
    public int AccountId { get; set; }
    public Account? Account { get; set; }

    public int LotteryId { get; set; }
    public Lottery? Lottery { get; set; }
}
