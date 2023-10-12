// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Exceptions;
using BankApp.Models;
using BankApp.Services.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers;

public class TransactionController : BaseController
{
    readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaction>>> Get([FromQuery] int? accountId)
    {
        try
        {
            if (accountId.HasValue)
            {
                var transaction = await _transactionService.GetByAccountId(accountId.Value).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Transaction), accountId);
                return new List<Transaction> { transaction };
            }
            else
            {
                var transactions = await _transactionService.Get().ConfigureAwait(false);
                return transactions.ToList();
            }
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetById(int id)
    {
        try
        {
            return await _transactionService.GetById(id).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(TransactionCreateSchema request)
    {
        try
        {
            return await _transactionService.Create(request).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (LessThanZeroException)
        {
            return BadRequest();
        }
    }

}
