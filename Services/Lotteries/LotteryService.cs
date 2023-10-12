// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Exceptions;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Services.Lotteries;

public class LotteryService
{
    private readonly DatabaseContext _dbContext;

    public LotteryService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Lottery>> Get()
    {
        if (!_dbContext.Lotteries.Any())
        {
            throw new NotFoundException();
        }
        return await _dbContext.Lotteries.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Lottery> GetById(int id)
    {
        if (!_dbContext.Lotteries.Any())
        {
            throw new NotFoundException(nameof(Lottery), id);
        }

        return await _dbContext.Lotteries.FindAsync(id).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Lottery), id);
    }

    public async Task<Lottery> GetByAccountId(int accountId)
    {
        if (!_dbContext.Lotteries.Any())
        {
            throw new NotFoundException();
        }

        return await _dbContext.Lotteries
            .FirstOrDefaultAsync(l => l.AccountLotteries.Any(
                al => al.AccountId == accountId
            )).ConfigureAwait(false) ?? throw new NotFoundException(nameof(AccountLottery), accountId);
    }

    public async Task<int> Create(LotteryCreateSchema request)
    {
        var newLottery = new Lottery
        {
            Name = request.name,
            PrizePool = 0,
            Price = request.price,
            StartDate = request.startDate,
            EndDate = request.endDate
        };

        _dbContext.Lotteries.Add(newLottery);

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return newLottery.LotteryId;
    }

    public async Task CreateAccount(LotteryUpdateAccountSchema request)
    {
        var lottery = await _dbContext.Lotteries.FindAsync(request.lotteryId).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Lottery), request.lotteryId);
        var account = await _dbContext.Accounts.FindAsync(request.accountId).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Account), request.accountId);

        var newAccountLottery = new AccountLottery
        {
            LotteryId = lottery.LotteryId,
            AccountId = account.AccountId
        };

        _dbContext.AccountsLotteries.Add(newAccountLottery);

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return;
    }

    public async Task DeleteAccount(LotteryUpdateAccountSchema request)
    {
        var accountLottery = await _dbContext.AccountsLotteries
            .FirstOrDefaultAsync(
                al => al.AccountId == request.accountId &&
                al.LotteryId == request.lotteryId
            )
            .ConfigureAwait(false) ?? throw new NotFoundException();

        _dbContext.AccountsLotteries.Remove(accountLottery);

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return;
    }


}
