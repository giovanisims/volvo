using model.clientes;
namespace service;

public class ClienteService
{
    private readonly Random r = new Random();
    private readonly List<Cliente> _cliente = new List<Cliente>
    {
    new Cliente("Giovani Sims", "giovani", "123456", "giovani@email.com", "41 99999-9999",
        new Endereco("Rua XV", 123, "", "Centro", "Curitiba", "PR", "80000-000")),
    new Cliente("Admin", "admin", "admin123", "admin@cultbook.com", "41 00000-0000",
        new Endereco("Rua Imaculada", 1155, "complemento", "Prado Velho", "Curitiba", "PR", "80215-901"))
    };

    public Cliente? GetPorLogin(string login)
    {
        return _cliente.Find(c => c.Login.Equals(login));
    }

    public string GerarSenhaSeVazia(string? senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
        {
            // password needs to be 8 digits with numbers with a letter an a symbol
            // I know this is far from teh best implementation for a password generator but it's just for testing purposes
            senha = r.Next(100000, 999999).ToString();
            // ASCII capital alphabet starts at 65 
            senha += (char)r.Next(65, 91);
            senha += (char)r.Next(33, 48); // Some random symbols
        }
        return senha;
    }

    public void AdicionarCliente(Cliente cliente)
    {
        _cliente.Add(cliente);
    }

    public List<Cliente> GetTodos() => _cliente;
}