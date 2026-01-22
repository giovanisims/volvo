namespace model;

public class EBook : Livro
{

    public double Tamanho { get; set; }

    public EBook(string isbn, string titulo, string descricao, string autor,
                      int estoque, double preco, string categoria, double tamanho)
        : base(isbn, titulo, descricao, autor, estoque, preco, categoria)
    {
        Tamanho = tamanho;
    }

    public override double CalcularPrecoTotal()
    {
        return Preco;
    }

    public override string ToString()
    {
        return base.ToString() + $"""

            Tamanho: {Tamanho} MBs
            """;
    }
}