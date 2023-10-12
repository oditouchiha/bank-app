// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Exceptions;
using BankApp.Models;
using BankApp.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Services.Accounts;

public class AccountService
{
    private readonly DatabaseContext _dbContext;

    public AccountService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Account>> Get()
    {
        if (!_dbContext.Accounts.Any())
        {
            throw new NotFoundException(nameof(Account));
        }
        return await _dbContext.Accounts.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Account> GetById(int id)
    {
        if (!_dbContext.Accounts.Any())
        {
            throw new NotFoundException(nameof(Account), id);
        }

        return await _dbContext.Accounts.FindAsync(id).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Account), id);
    }

    public async Task<Account> GetByCustomerId(int customerId)
    {
        if (!_dbContext.Accounts.Any())
        {
            throw new NotFoundException(nameof(Account), customerId);
        }

        return await _dbContext.Accounts.FirstOrDefaultAsync(a => a.CustomerId == customerId).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Account), customerId);
    }

    public async Task<int> Create(int customerId)
    {
        string newAccountNumber;

        var customer = await _dbContext.Customers.FindAsync(customerId).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Customer), customerId);

        var existingAccount = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.CustomerId == customerId).ConfigureAwait(false);
        if (existingAccount != null)
        {
            throw new AlreadyExistException();
        }

        while (true)
        {
            newAccountNumber = Utils.GenerateRandomAccountNumber();
            existingAccount = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Number == newAccountNumber).ConfigureAwait(false);
            if (existingAccount == null)
            {
                break;
            }
        }

        var newAccount = new Account
        {
            Balance = 0,
            Number = newAccountNumber,
            CustomerId = customer.CustomerId
        };

        _dbContext.Accounts.Add(newAccount);

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return newAccount.AccountId;
    }

    public async Task Delete(int id)
    {
        var account = await _dbContext.Accounts.FindAsync(id).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Account), id);
        _dbContext.Accounts.Remove(account);

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return;
    }

}
