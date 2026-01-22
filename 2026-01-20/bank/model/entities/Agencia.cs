namespace bank.model.entities;
 
public class BankBranch
{
    private CheckingAccount[] accounts = new CheckingAccount[10];
    private int _count = 0;
 
    public void OpenCheckingAccount(CheckingAccount account)
    {
        accounts[_count] = account;
        _count++;
    }
 
    public void OpenCreditAccount(CreditAccount account)
    {
        accounts[_count] = account;
        _count++;
    }
 
    public double CalculateTotalBalance()
    {
        double total = 0.0;
 
        for (int i = 0; i < _count; i++)
        {
            total += accounts[i].Balance;
        }
 
        return total;
    }
}