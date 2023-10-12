// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text;

namespace BankApp.Helpers;

public class Utils
{
    public static string GenerateRandomAccountNumber()
    {
        var length = 10;
        var chars = "0123456789";
        var accountNumber = new StringBuilder(length);
        var random = new Random();

        for (int i = 0; i < length; i++)
        {
            accountNumber.Append(chars[random.Next(chars.Length)]);
        }

        return accountNumber.ToString();
    }

}
