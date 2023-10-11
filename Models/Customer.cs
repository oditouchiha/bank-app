namespace BankApp.Models
{
    public class Customer
    {
        public int Id {get; set;}
        public string PhoneNumber {get; set;} = null!;
        public string Address {get; set;} = null!;
        public Account? Account { get; set; }
    }
}