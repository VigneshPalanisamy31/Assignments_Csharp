namespace FinanceTracker.Model
{
    internal class Transaction
    {
        public DateOnly Date { get; set; }
        public string UserID { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateOnly date, string id, string category, decimal amount)
        {
            Date = date;
            UserID = id;
            Category = category;
            Amount = amount;
        }
    }
}
