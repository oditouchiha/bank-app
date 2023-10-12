// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BankApp.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException()
        : base()
    {
    }

    public AlreadyExistException(string message)
        : base(message)
    {
    }

    public AlreadyExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AlreadyExistException(string name, object key)
        : base($"Entity \"{name}\" ({key}) is already exists.")
    {
    }
}
