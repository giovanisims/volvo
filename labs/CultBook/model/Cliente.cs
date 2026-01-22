namespace model;
using System.Text; // Used by string builder

public class Cliente
{
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string Fone { get; set; }

    public Endereco[] Enderecos { get; set; }
    public Pedido[] Pedidos { get; set; }

    private int _qtdEnderecos;
    private int _qtdPedidos;

    public Cliente(string nome, string login, string senha, string email, string fone, Endereco endereco)
    {
        Nome = nome;
        Login = login;
        Senha = senha;
        Email = email;
        Fone = fone;

        Enderecos = new Endereco[10];
        Pedidos = new Pedido[10];

        _qtdEnderecos = 0;
        _qtdPedidos = 0;

        InserirEndereco(endereco);
    }

    public bool InserirPedido(Pedido pedido)
    {
        if (_qtdPedidos >= Pedidos.Length)
            return false;

        Pedidos[_qtdPedidos] = pedido;
        _qtdPedidos++;
        return true;
    }

    public bool InserirEndereco(Endereco endereco)
    {
        if (_qtdEnderecos >= Enderecos.Length)
            return false;

        Enderecos[_qtdEnderecos] = endereco;
        _qtdEnderecos++;
        return true;
    }

    public override string ToString()
    {
        // "StingBuilder" is used here since we can keep the existing logic 
        // and pretty much just replace all instances of "WriteLine" with "AppendLine"
        StringBuilder sb = new();

        sb.AppendLine($"""
            === Cliente ===
            Nome: {Nome}
            Login: {Login}
            Senha: {Senha}
            Email: {Email}
            Fone: {Fone}
            """);

        sb.AppendLine("Enderecos:");
        for (int i = 0; i < _qtdEnderecos; i++)
        {
            sb.AppendLine($"--- Endereco {i + 1} ---");
            // Append line also works with ToString so we just replace that aswell
            sb.AppendLine(Enderecos[i].ToString());
        }

        sb.AppendLine("Pedidos:");
        for (int i = 0; i < _qtdPedidos; i++)
        {
            sb.AppendLine($"--- Pedido {i + 1} ---");
            sb.AppendLine(Pedidos[i].ToString());
        }

        return sb.ToString(); // And then we return the ToString method FROM StringBuilder
    }
}
