namespace BankApp.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string Number { get; set; } = null!;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<Transaction>? DepositTransactions { get; set; }
        public ICollection<Transaction>? WithdrawTransactions { get; set; }

    }
}