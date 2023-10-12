// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Exceptions;
using BankApp.Models;
using BankApp.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers;

public class AccountController : BaseController
{
    readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> Get([FromQuery] int? customerId)
    {
        try
        {
            if (customerId.HasValue)
            {
                var account = await _accountService.GetByCustomerId(customerId.Value).ConfigureAwait(false);
                if (account == null)
                {
                    return NotFound();
                }
                return new List<Account> { account }; // Wrap the single account in a list
            }
            else
            {
                var accounts = await _accountService.Get().ConfigureAwait(false);
                return accounts.ToList();
            }
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> GetById(int id)
    {
        try
        {
            return await _accountService.GetById(id).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(int customerId)
    {
        try
        {
            return await _accountService.Create(customerId).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (AlreadyExistException)
        {
            return Conflict();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _accountService.Delete(id).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
