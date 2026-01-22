namespace bank.model.entities;
public class CheckingAccount
{

    // Instance variables
    public int Number {get; set;} // Property, autoamted getter and setter
    private string Owner;

    private double _balance;
    public double Balance
    {
        get { return _balance; }
        protected set { _balance = value; } // Changed from private to protected
    }
    private string Password;

    public CheckingAccount() : this(0, password: "", owner: "")
    {
 
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

    public virtual void Withdraw(double amnt) // Added virtual
    {
        if (Balance >= amnt)
        {
            Balance -= amnt;
        }
    }
}