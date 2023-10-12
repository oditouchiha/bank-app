// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Exceptions;

public class LessThanZeroException : Exception
{
    public LessThanZeroException()
    : base()
    {
    }

    public LessThanZeroException(string name)
        : base($"Entity \"{name}\"'s amount cannot less than zero.")
    {
    }

    public LessThanZeroException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

}
