// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Models;

public class Customer : Auditable
{
    public int CustomerId { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Account? Account { get; set; }
    public string? Name { get; set; }
}
