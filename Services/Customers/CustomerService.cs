// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Exceptions;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Services.Customers;

public class CustomerService
{
    private readonly DatabaseContext _dbContext;

    public CustomerService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Customer>> Get()
    {
        if (!_dbContext.Customers.Any())
        {
            throw new NotFoundException(nameof(Customer));
        }
        return await _dbContext.Customers.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Customer> Get(int id)
    {
        if (!_dbContext.Customers.Any())
        {
            throw new NotFoundException(nameof(Customer), id);
        }

        var customer = await _dbContext.Customers.FindAsync(id).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Customer), id);

        return customer;
    }

    public async Task<int> Create(CustomerCreateSchema request)
    {
        var newCustomer = new Customer
        {
            Name = request.name,
            Address = request.address,
            PhoneNumber = request.phoneNumber
        };

        _dbContext.Customers.Add(newCustomer);

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return newCustomer.CustomerId;
    }

    public async Task Update(CustomerUpdateSchema request)
    {
        var customer = await _dbContext.Customers.FindAsync(request.CustomerId).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Customer), request.CustomerId);
        if (request.name != null)
        {
            customer.Name = request.name;
        }

        if (request.address != null)
        {
            customer.Address = request.address;
        }

        if (request.phoneNumber != null)
        {
            customer.PhoneNumber = request.phoneNumber;
        }

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return;
    }

    public async Task Delete(int id)
    {
        var customer = await _dbContext.Customers.FindAsync(id).ConfigureAwait(false) ?? throw new NotFoundException(nameof(Customer), id);
        _dbContext.Customers.Remove(customer);

        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

        return;
    }

}
