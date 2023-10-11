using System.Collections.ObjectModel;

namespace BankApp.Models
{
    public class Account
    {
        public Account()
        {
            AccountPortofolios = new Collection<AccountPortofolio>();
        }

        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string Number { get; set; } = null!;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<Transaction>? DepositTransactions { get; set; }
        public ICollection<Transaction>? WithdrawTransactions { get; set; }

        public ICollection<AccountPortofolio> AccountPortofolios { get; set; }
    }
}