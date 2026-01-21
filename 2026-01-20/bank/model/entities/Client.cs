namespace bank.model.entities;

public class Client
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }

    // Multiple accounts per client
    public object[] Accounts { get; set; } 

    public Client(string name, string cpf, string email)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
    }
}