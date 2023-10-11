namespace BankApp.Models
{
    public class AccountPortofolio
    {
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

        public int PortofolioId { get; set; }
        public Portofolio Portofolio { get; set; } = null!;
    }
}