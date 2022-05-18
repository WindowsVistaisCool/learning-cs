namespace Classes;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance) { }

    public override void PerformMonthEndTransactions()
    {
        if (Balance > 500m)
        {
            MakeDeposit(Balance * 0.05m, DateTime.Now, "Interest earned");
        }
    }
}