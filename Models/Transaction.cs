namespace BankApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = null!;

        public int DepositorAccountId { get; set; }
        public Account DepositorAccount { get; set; } = null!;
        public int WithdrawlAccountId { get; set; }
        public Account WithdrawlAccount { get; set; } = null!;
    }
}