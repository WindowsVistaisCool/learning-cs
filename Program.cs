using Classes;

var account = new BankAccount("Mr. Bryan Walton", 110000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

Console.WriteLine("tets");
string? test = Console.ReadLine();
if (test == null)
{
    Console.WriteLine("test");
}
else
{
    Console.WriteLine("test2");
}

return;

while (true)
{
    Console.WriteLine("Enter an option: ");
    string? option = Console.ReadLine();
    if (option == null){
        Console.WriteLine("invlaid");
        continue;
    }
    bool recievedQuitSig = false;
    switch (option)
    {
        case "deposit":
            Console.WriteLine("Enter deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter deposit date (MM/DD/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter deposit note: ");
            string note = Console.ReadLine();
            account.MakeDeposit(amount, date, note);
            Console.WriteLine($"Account {account.Number} was successfully deposited {amount} on {date} with a new balance of {account.Balance}.");
            break;
        case "quit":
            Console.WriteLine("Thank you for using the bank app!");
            recievedQuitSig = true;
            break;
        default:
            Console.WriteLine("Invalid amount!");
            break;
    }
    if (recievedQuitSig) break;
}