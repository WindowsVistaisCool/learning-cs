namespace Classes;

public class Transaction
{
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Notes { get; }

    public Transaction(decimal amount, DateTime date, string Note)
    {
        Amount = amount;
        Date = date;
        Notes = Note;
    }
}