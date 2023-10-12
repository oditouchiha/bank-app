// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.ObjectModel;

namespace BankApp.Models;

public class Portofolio : Auditable
{
    public Portofolio()
    {
        AccountPortofolios = new Collection<AccountPortofolio>();
    }

    public required string Index { get; set; }
    public int PortofolioId { get; set; }
    public decimal Balance { get; set; }
    public ICollection<AccountPortofolio> AccountPortofolios { get; set; }
}
