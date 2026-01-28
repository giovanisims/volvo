namespace model.dto;

public class LivroDTO
{
    public string Tipo { get; set; }
    public string Isbn { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Autor { get; set; }
    public int Estoque { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }

    // LivroFisico
    public double? Peso { get; set; }
    public decimal? ValorFrete { get; set; }

    // AudioLivro
    public string? Narrador { get; set; }
    public double? TempoDeDuracao { get; set; }

    // EBook
    public double? Tamanho { get; set; }
}