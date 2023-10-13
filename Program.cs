// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Services.Accounts;
using BankApp.Services.Customers;
using BankApp.Services.Lotteries;
using BankApp.Services.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BankApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<CustomerService>();
        builder.Services.AddTransient<AccountService>();
        builder.Services.AddTransient<TransactionService>();
        builder.Services.AddTransient<LotteryService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<DatabaseContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            context.Database.EnsureCreated();
            context.Seed();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
