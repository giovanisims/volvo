namespace CultBook.model;

public class ItemDePedido
{
    public int Qtde{get; set;}
    public double Preco{get; set;}
    public Pedido Pedido { get; set; }
    public Livro Livro { get; set; }

    public ItemDePedido() { }

    public ItemDePedido(Livro livro, int qtde)
    {
        Livro = livro;
        Qtde = qtde;
        Preco = livro.Preco;
    }

    public void Imprimir()
    {
        Console.WriteLine($"Item de Pedido: Quantidade: {Qtde}, Preço Unitário: {Preco:C}, Total: {(Qtde * Preco):C}");
    }
}