namespace bank;

using  bank.model.entities;

class Program
{
    static void Main(string[] args)
    {
        CheckingAccount cc = new CheckingAccount();
        CheckingAccount cc2 = new CheckingAccount();

        cc.Number = 67;
        cc.Owner = "John Doe";
        cc.Password = "password";

        cc.Deposit(500);
        cc.Withdraw(200);
        cc.Withdraw(70);

        Console.WriteLine("Current balance Account 2 " + cc2.DisplayBalance());

        Console.WriteLine("Current balance Account 1 " + cc.DisplayBalance());
    }
}