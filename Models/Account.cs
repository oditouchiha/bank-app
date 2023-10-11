namespace BankApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public float Balance { get; set; }
        public string Number { get; set; } = null!;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}