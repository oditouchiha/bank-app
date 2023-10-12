// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Services.Customers;

public class CustomerCreateSchema
{
    public string name { get; set; } = null!;
    public string phoneNumber { get; set; } = null!;
    public string address { get; set; } = null!;
}
