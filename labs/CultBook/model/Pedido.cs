
namespace CultBook.model;

public class Pedido
{
    public int Numero { get; set; }
    public DateTime DataEmissao { get; set; }
    public string FormaPagamento { get; set; }
    public double ValorTotal { get; set; }
    public string Situacao { get; set; }

    // Lowercase field names because apparently that's the convention in C#
    private Endereco endereco;
    private ItemDePedido[] itens;
    // Need this to keep track when adding multiple different items to this order
    private int indiceArray;


    public Pedido(int numero, DateTime dataEmissao, string formaPagamento, double valorTotal, string situacao)
    {
        Numero = numero;
        DataEmissao = dataEmissao;
        FormaPagamento = formaPagamento;
        ValorTotal = valorTotal;
        Situacao = situacao;

        indiceArray = 0;

        // The array here is beign initialized with a fixed size, probably fixing that in the next class 
        itens = new ItemDePedido[10];
    }

    public ItemDePedido[] GetItens()
    {
        return itens;
    }

    public void SetEndereco(Endereco endereco)
    {
        this.endereco = endereco;
    }

    public Endereco GetEndereco()
    {
        return endereco;
    }

    public void InserirItem(ItemDePedido item)
    {
        if (indiceArray < itens.Length)
        {
            itens[indiceArray] = item;

            ValorTotal += item.Preco * item.Qtde;

            item.SetPedido(this);

            indiceArray++;
        }
    }

public void Imprimir()
    {
        Console.WriteLine($"""
        Número: {Numero}
        Data de Emissão: {DataEmissao:d}
        Forma de Pagamento: {FormaPagamento}
        Valor Total: {ValorTotal:C}
        Situação: {Situacao}
        Items do Pedido:
        """);

        // Not sure if I need to actually show the books here but better safe than sorry
        for (int i = 0; i < indiceArray; i++)
        {
            if (itens[i] != null)
            {
                itens[i].Imprimir();
            }
        }
    }
}