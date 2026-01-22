namespace model;
using System.Text;

public class Pedido
{
    public int Numero { get; set; }
    public string DataEmissao { get; set; }
    public string FormaPagamento { get; set; }
    public double ValorTotal { get; set; }
    public string Situacao { get; set; }

    public Cliente? Cliente { get; set; }
    public Endereco? EnderecoEntrega { get; set; }

    public ItemDePedido[] Itens { get; set; }
    private int _qtdItens;

    public Pedido(int numero, string dataEmissao, string formaPagamento,
                  string situacao, ItemDePedido item)
    {
        Numero = numero;
        DataEmissao = dataEmissao;
        FormaPagamento = formaPagamento;
        Situacao = situacao;

        Itens = new ItemDePedido[10];
        _qtdItens = 0;
        ValorTotal = 0;

        InserirItem(item);
    }

    public bool InserirItem(ItemDePedido item)
    {
        // array fixo: insere se houver espaço
        if (_qtdItens >= Itens.Length)
            return false;

        Itens[_qtdItens] = item;
        _qtdItens++;

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
        for (int i = 0; i < _qtdItens; i++)
        {
            sb.AppendLine($"--- Item {i + 1} ---");
            sb.AppendLine(Itens[i].ToString());
        }

        return sb.ToString();
    }
}