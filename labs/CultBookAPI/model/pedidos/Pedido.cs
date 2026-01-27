namespace model.pedidos;

using System.Text;
using model.clientes;
using model.pedidos;

public class Pedido
{
    public int Numero { get; set; }
    public string DataEmissao { get; set; }
    public string FormaPagamento { get; set; }
    public decimal ValorTotal { get; set; }
    public string Situacao { get; set; }
    
    public Cliente? Cliente { get; set; }
    public Endereco? EnderecoEntrega { get; set; }

    public List<ItemDePedido> Itens { get; set; }

    public Pedido(int numero, string dataEmissao, string formaPagamento,
                  string situacao, ItemDePedido item)
    {
        Numero = numero;
        DataEmissao = dataEmissao;
        FormaPagamento = formaPagamento;
        Situacao = situacao;

        Itens = new List<ItemDePedido>();
        ValorTotal = 0m;

        InserirItem(item);
    }

    public bool InserirItem(ItemDePedido item)
    {
        Itens.Add(item);

        ValorTotal += item.Preco * item.Qtde;
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine($"""
            === Pedido ===
            Numero: {Numero}
            DataEmissao: {DataEmissao}
            FormaPagamento: {FormaPagamento}
            Situacao: {Situacao}
            ValorTotal: {ValorTotal}
            """);

        if (Cliente != null)
        {
            sb.AppendLine("Cliente:");
            sb.AppendLine(Cliente.ToString());
        }

        if (EnderecoEntrega != null)
        {
            sb.AppendLine("EnderecoEntrega:");
            sb.AppendLine(EnderecoEntrega.ToString());
        }

        sb.AppendLine("Itens:");
        for (int i = 0; i < Itens.Count; i++)
        {
            sb.AppendLine($"--- Item {i + 1} ---");
            sb.AppendLine(Itens[i].ToString());
        }
        return sb.ToString();
    }
}