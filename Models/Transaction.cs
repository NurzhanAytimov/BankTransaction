namespace BankTransaction.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Benefeciary { get; set; }
        public string BankName { get; set; }
        public int Summa { get; set; }
        public DateTime Date { get; set; }
    }
}
