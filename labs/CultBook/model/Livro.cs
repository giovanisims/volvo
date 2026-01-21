namespace CultBook.model;

public class Livro
{
    public string Isbn { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Autor { get; set; }
    public int Estoque { get; set; }
    public double Preco { get; set; }
    public string Figura { get; set; }
    public DateTime DataCadastro { get; set; }
    public string Categoria { get; set; }


    public Livro(string isbn, string titulo, string descricao, string autor, int estoque, double preco, string figura, DateTime dataCadastro, string categoria)
    {
        Isbn = isbn;
        Titulo = titulo;
        Descricao = descricao;
        Autor = autor;
        Estoque = estoque;
        Preco = preco;
        Figura = figura;
        DataCadastro = dataCadastro;
        Categoria = categoria;
    }

    // public void Imprimir()
    // {
    //     Console.WriteLine($"Livro: {Titulo} ({Autor}) - {Categoria}, ISBN: {Isbn}, Preço: {Preco:C}, Estoque: {Estoque}");
    // }
}