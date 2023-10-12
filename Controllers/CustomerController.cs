// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Exceptions;
using BankApp.Models;
using BankApp.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers;

public class CustomerController : BaseController
{
    readonly CustomerService _customerService;

    public CustomerController(CustomerService customerservice)
    {
        _customerService = customerservice;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> Get()
    {
        try
        {
            return await _customerService.Get().ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Customer>> Get(int id)
    {
        try
        {
            return await _customerService.Get(id).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CustomerCreateSchema request)
    {
        try
        {
            return await _customerService.Create(request).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(CustomerUpdateSchema request)
    {
        try
        {
            await _customerService.Update(request).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _customerService.Delete(id).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
