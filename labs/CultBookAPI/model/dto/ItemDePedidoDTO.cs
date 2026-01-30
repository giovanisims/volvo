using System.ComponentModel;

namespace model.dto;

public class ItemDePedidoDTO
{
    public string Isbn { get; set; } = string.Empty;
    [DefaultValue(1)]
    public int Qtde { get; set; }
    public decimal Preco { get; set; }
}