using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Configurations
{
    public class AccountPortofolioConfiguration : IEntityTypeConfiguration<AccountPortofolio>
    {
        public void Configure(EntityTypeBuilder<AccountPortofolio> builder)
        {
            builder
                .HasKey(ap => new { ap.AccountId, ap.PortofolioId });

            builder
                .HasOne(ap => ap.Account)
                .WithMany(a => a.AccountPortofolios)
                .HasForeignKey(ap => ap.AccountId);

            builder
                .HasOne(ap => ap.Portofolio)
                .WithMany(p => p.AccountPortofolios)
                .HasForeignKey(ap => ap.PortofolioId);
        }
    }
}