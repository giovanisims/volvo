namespace CultBook.model;

public class ItemDePedido
{
    public int Qtde { get; set; }
    public double Preco { get; set; }
    private Pedido pedido;
    private Livro livro;


    public ItemDePedido(Livro livro, int qtde)
    {
        this.livro = livro;
        Qtde = qtde;
        Preco = livro.Preco;
    }

    public Livro GetLivro()
    {
        return livro;
    }

    public Pedido GetPedido()
    {
        return pedido;
    }

    public void SetPedido(Pedido pedido)
    {
        this.pedido = pedido;
    }

public void Imprimir()
    {
        Console.WriteLine($"""
        Item: {livro.Titulo}
        Quantidade: {Qtde}
        Preço Unitário: {Preco:C}
        Total: {Qtde * Preco:C}
        """);
    }
}