namespace bank;

using  bank.model.entities;

class Program
{
    static void Main(string[] args)
    {
        CheckingAccount cc = new CheckingAccount(67,"John Doe", "password");
        CreditAccount ce = new CreditAccount( 69,"Jane Doe", "passphrase", 1000.20);

        // cc.Number = 67;
        // cc.Owner = "John Doe";
        // cc.Password = "password";

        cc.Deposit(500);
        cc.Withdraw(200);
        cc.Withdraw(70);

        Console.WriteLine("Current balance Account 2 " + ce.Balance);

        Console.WriteLine("Current balance Account 1 " + cc.Balance);

        Console.WriteLine("Limit is: " + ce.Limit);
    }
}