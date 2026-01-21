namespace CultBook.model;

public class Cliente
{
    public string Nome{get; set;}
    public string Login{get; set;}
    public string Senha{get; set;}
    public string Email{get; set;}
    public string Fone{get; set;}
    public Endereco[] Enderecos { get; set; }
    public Pedido[] Pedidos { get; set; }


    public Cliente() {}

    public Cliente(string nome, string login, string senha, string email, string fone, Endereco endereco)
    {
        Nome = nome;
        Login = login;
        Senha = senha;
        Email = email;
        Fone = fone;
        Enderecos = new Endereco[] { endereco };
        Pedidos = new Pedido[0];
    }

    public void InserirEndereço(Endereco endereco)
    {
        Endereco[] temp = Enderecos;
        Array.Resize(ref temp, (Enderecos?.Length ?? 0) + 1);
        Enderecos = temp;
        Enderecos[Enderecos.Length - 1] = endereco;
    }

    public void InserirPedido(Pedido pedido)
    {
        Pedido[] temp = Pedidos;
        Array.Resize(ref temp, (Pedidos?.Length ?? 0) + 1);
        Pedidos = temp;
        Pedidos[Pedidos.Length - 1] = pedido;
    }

    public void Imprimir()
    {
        Console.WriteLine($"Cliente: {Nome}, Login: {Login}, Email: {Email}, Fone: {Fone}");
    }
}