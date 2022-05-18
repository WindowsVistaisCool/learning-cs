using Classes;

var account = new BankAccount("Mr. Bryan Walton", 110000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

while (true)
{
    Console.WriteLine("Enter an option: ");
    string? option = Console.ReadLine();
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
        case "withdraw":
            Console.WriteLine("Enter withdrawal amount: ");
            amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter withdrawal date (MM/DD/YYYY): ");
            date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter withdrawal note: ");
            note = Console.ReadLine();
            try
            {
                account.MakeWithdrawal(amount, date, note);
                Console.WriteLine($"Account {account.Number} was successfully withdrawn {amount} on {date} with a new balance of {account.Balance}.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "balance":
            Console.WriteLine($"The balance for account {account.Number} is {account.Balance}.");
            break;
        case "quit":
            Console.WriteLine("Thank you for using the bank app!");
            recievedQuitSig = true;
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
    if (recievedQuitSig) break;
}