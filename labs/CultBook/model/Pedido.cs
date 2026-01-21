
namespace CultBook.model;

public class Pedido
{
    public int Numero {get; set;}
    public DateTime DataEmissao {get; set;}
    public string FormaPagamento {get; set;}
    public double ValorTotal {get; set;}
    public string Situacao {get; set;}
    public Endereco Endereco {get; set;}
    public ItemDePedido[] Itens { get; set; }

    public Pedido() { }

    public Pedido(int numero, DateTime dataEmissao, string formaPagamento, double valorTotal, string situacao)
    {
        Numero = numero;
        DataEmissao = dataEmissao;
        FormaPagamento = formaPagamento;
        ValorTotal = valorTotal;
        Situacao = situacao;
        Itens = new ItemDePedido[0];
    }

    public void SetEndereco(Endereco endereco)
    {
        Endereco = endereco;
    }

    public void InserirItem(Livro livro)
    {
        ItemDePedido[] temp = Itens;
        Array.Resize(ref temp, (temp?.Length ?? 0) + 1);
        Itens = temp;
        
        ItemDePedido novoItem = new ItemDePedido(livro, 1);
        novoItem.Pedido = this;
        
        Itens[Itens.Length - 1] = novoItem;
        
        ValorTotal += novoItem.Preco * novoItem.Qtde;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Pedido #{Numero} - Emissão: {DataEmissao}, Pagamento: {FormaPagamento}, Total: {ValorTotal:C}, Situação: {Situacao}");
        if (Endereco != null) Console.WriteLine("Endereço de Entrega: " + Endereco.Rua);
        if (Itens != null)
        {
            foreach (var item in Itens)
            {
                item.Imprimir();
            }
        }
    }
}