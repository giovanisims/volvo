namespace model;

public abstract class Livro
{
    public string Isbn { get; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Autor { get; set; }
    public int Estoque { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }

    protected Livro(string isbn, string titulo, string descricao, string autor,
                         int estoque, decimal preco, string categoria)
    {
        Isbn = isbn;
        Titulo = titulo;
        Descricao = descricao;
        Autor = autor;
        Estoque = estoque;
        Preco = preco;
        Categoria = categoria;
    }

    public abstract decimal CalcularPrecoTotal();

    public override string ToString()
    {
        return $"""
            === Livro ===
            ISBN: {Isbn}
            Titulo: {Titulo}
            Descricao: {Descricao}
            Autor: {Autor}
            Estoque: {Estoque}
            Preco: {Preco.ToString("C", new System.Globalization.CultureInfo("pt-BR"))}
            Categoria: {Categoria}
            """;
    }
}