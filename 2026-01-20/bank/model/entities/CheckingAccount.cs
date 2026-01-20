namespace bank.model.entities;
public class CheckingAccount
{

    // Instance variables
    public int Number;
    public string Owner;
    public double Balance;
    public string Password;

    public void Withdraw(double amnt)
    {
        Balance -= amnt;
    }

        public void Deposit(double amnt)
    {
        Balance += amnt;
    }

        public double DisplayBalance()
    {
        return Balance;
    }
}