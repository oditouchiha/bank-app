// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Models;

public class AccountPortofolio
{
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;

    public int PortofolioId { get; set; }
    public Portofolio Portofolio { get; set; } = null!;
}
