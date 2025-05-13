namespace FinanceTracker.Model
{
    internal class Transaction
    {

        public DateTime date;
        public string name;
        public string category;
        public double amount;


        public Transaction(DateTime date, string name, string category, double amount)
        {
            this.date = date;
            this.name = name;
            this.category = category;
            this.amount = amount;
        }
    }
}
