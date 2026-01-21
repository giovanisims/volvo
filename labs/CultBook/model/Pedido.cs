
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


    public Pedido(int numero, DateTime dataEmissao, string formaPagamento, double valorTotal, string situacao)
    {
        Numero = numero;
        DataEmissao = dataEmissao;
        FormaPagamento = formaPagamento;
        ValorTotal = valorTotal;
        Situacao = situacao;

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
        // Optional "this." parameter here 
        return endereco;
    }

    public void InserirItem(ItemDePedido item) { }

    // public void Imprimir()
    // {
    //     Console.WriteLine($"Pedido #{Numero} - Emissão: {DataEmissao}, Pagamento: {FormaPagamento}, Total: {ValorTotal:C}, Situação: {Situacao}");
    // }
}