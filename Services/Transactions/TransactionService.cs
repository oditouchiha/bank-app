// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Exceptions;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Services.Transactions;

public class TransactionService
{
    private readonly DatabaseContext _dbContext;

    public TransactionService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Transaction>> Get()
    {
        if (!_dbContext.Transactions.Any())
        {
            throw new NotFoundException(nameof(Customer));
        }
        return await _dbContext.Transactions.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Transaction> GetById(int id)
    {
        return await _dbContext.Transactions.FindAsync(id).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Account), id);
    }

    public async Task<Transaction> GetByAccountId(int accountId)
    {
        return await _dbContext.Transactions
            .FirstOrDefaultAsync(t => t.DepositorAccountId == accountId || t.WithdrawlAccountId == accountId)
            .ConfigureAwait(false) ?? throw new NotFoundException(nameof(Account), accountId);
    }

    public async Task<int> Create(TransactionCreateSchema request)
    {
        var existingWithdrawlAccount = await _dbContext.Accounts.FindAsync(request.withdrawlAccountId).ConfigureAwait(false)
            ?? throw new NotFoundException(nameof(Account), request.withdrawlAccountId);

        var existingDepositorAccount = await _dbContext.Accounts.FindAsync(request.depositorAccountId).ConfigureAwait(false)
            ?? throw new NotFoundException(nameof(Account), request.depositorAccountId);

        var newTransaction = new Transaction
        {
            Timestamp = DateTime.Now,
            Amount = request.amount,
            Currency = request.currency,
            DepositorAccountId = existingDepositorAccount.AccountId,
            WithdrawlAccountId = existingWithdrawlAccount.AccountId
        };

        _dbContext.Transactions.Add(newTransaction);

        existingWithdrawlAccount.Balance -= request.amount;

        if (existingWithdrawlAccount.Balance < 0)
        {
            throw new LessThanZeroException();
        }

        existingDepositorAccount.Balance += request.amount;

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return newTransaction.TransactionId;
    }

}
