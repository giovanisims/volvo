namespace model.dto;

public class ItemDePedidoDTO
{
    public string Isbn { get; set; } = string.Empty;
    public int Qtde { get; set; }
    public decimal Preco { get; set; }
}