namespace Classes;

public class BankAccount
{
    private readonly decimal _minimumBalance;
    private static int accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }

            return balance;
        }
    }

    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) {}

    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        this.Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        Owner = name;
        _minimumBalance = minimumBalance;
        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    public virtual void PerformMonthEndTransactions() { }

    private List<Transaction> allTransactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);
        allTransactions.Add(withdrawal);
        if (overdraftTransaction != null)
            allTransactions.Add(overdraftTransaction);
    }

    protected virtual Transaction? CheckWithdrawalLimit(bool isOverDrawn)
    {
        if (isOverDrawn)
        {
            throw new InvalidOperationException("not enough funds");
        }
        else return default;
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }

        return report.ToString();
    }
}
