namespace CultBook.model;

public class Cliente
{
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Fone { get; set; }

    private Pedido[] pedidos;
    private Endereco[] enderecos;
    private int indicePedidos = 0;
    private int indiceEnderecos = 0;
    public Cliente(string nome, string login, string senha, string email, string fone)
    {
        Nome = nome;
        Login = login;
        Senha = senha;
        Email = email;
        Fone = fone;
        // Also fixed size gotta fix that
        pedidos = new Pedido[10];
        enderecos = new Endereco[5];
    }

    public Pedido[] GetPedidos()
    {
        return pedidos;
    }

    public Endereco[] GetEnderecos()
    {
        return enderecos;
    }

    public void InserirEndereco(Endereco endereco)
    {
        if (indiceEnderecos < enderecos.Length)
        {
            enderecos[indiceEnderecos] = endereco;
            indiceEnderecos++;
        }
    }

    public void InserirPedido(Pedido pedido)
    {
        if (indicePedidos < pedidos.Length)
        {
            pedidos[indicePedidos] = pedido;
            indicePedidos++;
        }
    }

    // public void Imprimir()
    // {
    //     Console.WriteLine($"Cliente: {Nome}, Login: {Login}, Email: {Email}, Fone: {Fone}");
    // }
}