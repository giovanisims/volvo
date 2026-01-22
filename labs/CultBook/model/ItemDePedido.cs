using System.Text;
namespace model;

public class ItemDePedido
{
    public int Qtde { get; set; }
    public double Preco { get; set; }
    public Livro Livro { get; set; } 

    public ItemDePedido(Livro livro, int qtde = 1, double preco = 0)
    {
        Livro = livro;
        Qtde = qtde;
        Preco = preco;
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine($"""
            === ItemDePedido ===
            Qtde: {Qtde}
            Preco: {Preco}
            Livro do item:
            """);
        sb.AppendLine(Livro.ToString());

        return sb.ToString();
    }
}