namespace model;

public class AudioLivro : Livro
{
    public string Narrador { get; set; }
    public double TempoDeDuracao { get; set; }
    public string Midia {get; set;}

    public AudioLivro(string isbn, string titulo, string descricao, string autor,
                      int estoque, double preco, string categoria, 
                      string narrador, double tempoDeDuracao, string midia) 
        : base(isbn, titulo, descricao, autor, estoque, preco, categoria)
    {
        Narrador = narrador;
        TempoDeDuracao = tempoDeDuracao;
        Midia = midia;
    }

    public override string ToString()
    {
        return base.ToString() + $"""
            Narrador: {Narrador}
            Duracao: {TempoDeDuracao}
            Midia: {Midia}
            """;
    }
}