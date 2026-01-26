namespace model;
using System.Text; // Used by string builder

public class Cliente : IAutenticavel
{
    public string Nome { get; set; }
    public string Login { get; set; }
    private string _senha;
    public string Email { get; set; }
    public string Fone { get; set; }

    public List<Endereco> Enderecos { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public Cliente(string nome, string login, string senha, string email, string fone, Endereco endereco)
    {
        Nome = nome;
        Login = login;
        _senha = senha;
        Email = email;
        Fone = fone;

        Enderecos = new List<Endereco>();
        Pedidos = new List<Pedido>();

        InserirEndereco(endereco);
    }

    public void SetSenha(string novaSenha) {
        _senha = novaSenha;
    }

    public bool ValidarSenha(string senha)
    {
        return _senha == senha;
    }

    public bool InserirPedido(Pedido pedido)
    {
        Pedidos.Add(pedido);
        return true;
    }

    public bool InserirEndereco(Endereco endereco)
    {
        Enderecos.Add(endereco);
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
            Senha: {_senha}
            Email: {Email}
            Fone: {Fone}
            """);

        sb.AppendLine("Enderecos:");
        for (int i = 0; i < Enderecos.Count; i++)
        {
            sb.AppendLine($"--- Endereco {i + 1} ---");
            // Append line also works with ToString so we just replace that aswell
            sb.AppendLine(Enderecos[i].ToString());
        }

        sb.AppendLine("Pedidos:");
        for (int i = 0; i < Pedidos.Count; i++)
        {
            sb.AppendLine($"--- Pedido {i + 1} ---");
            sb.AppendLine(Pedidos[i].ToString());
        }

        return sb.ToString(); // And then we return the ToString method FROM StringBuilder
    }
}
