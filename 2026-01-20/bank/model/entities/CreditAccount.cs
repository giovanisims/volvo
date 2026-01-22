namespace bank.model.entities;

public class CreditAccount : CheckingAccount
{
    public double Limit { get; set; }

    public CreditAccount() : base(1, "No client", "0000")
    {
        Limit = 0.0;
    }

    public CreditAccount(int number, string owner, string password, double limit) 
        : base(number, owner, password)
    {
        Limit = limit;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= (Balance + Limit))
        {
            Balance -= amount;
        }
    }
}