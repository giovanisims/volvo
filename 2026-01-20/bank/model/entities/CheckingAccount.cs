namespace bank.model.entities;
public class CheckingAccount
{

    // Instance variables
    public int Number {get; set;} // Property, autoamted getter and setter
    private string Owner;

    private double _balance;
    public double Balance
    {
        get { return _balance;}
        
        private set { _balance = value; }
    }
    private string Password;

    public CheckingAccount()
    {
        Number = 0;
        Owner = "";
        Balance = 0;
        Password = "";
    }

    public CheckingAccount(int number, string owner, string password)
    {
        Number = number;
        Owner = owner;
        Password = password;
        Balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public void Withdraw(double amnt)
    {
        if (Balance >= amnt)
        {
            Balance -= amnt;
        }
    }
}