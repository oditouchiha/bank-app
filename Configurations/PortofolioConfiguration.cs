// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Configurations;

public class PortofolioConfiguration : IEntityTypeConfiguration<Portofolio>
{
    public void Configure(EntityTypeBuilder<Portofolio> builder)
    {
        builder
            .HasMany(p => p.AccountPortofolios)
            .WithOne(ap => ap.Portofolio)
            .HasForeignKey(ap => ap.PortofolioId);
    }
}
