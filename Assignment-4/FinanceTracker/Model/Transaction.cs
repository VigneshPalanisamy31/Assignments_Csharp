namespace FinanceTracker.Model
{
    internal class Transaction
    {
        public DateOnly Date { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateOnly date, string name, string category, decimal amount)
        {
            Date = date;
            Name = name;
            Category = category;
            Amount = amount;
        }
    }
}
