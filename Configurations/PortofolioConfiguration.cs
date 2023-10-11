using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace BankApp.Configurations
{
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
}