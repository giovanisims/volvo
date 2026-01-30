using System.ComponentModel;
using model.dto;

namespace model.dto;

public class PedidoDTO
{
    public string ClienteLogin { get; set; } 
    public int NumeroPedido { get; set; }
    public string DataEmissao { get; set; }
    public string FormaPagamento { get; set; }
    public decimal ValorTotal { get; set; }
    [DefaultValue("aberto")]
    public string Situacao { get; set; } = "aberto";
    public EnderecoDTO? EnderecoEntrega { get; set; }
    public List<ItemDePedidoDTO> Itens { get; set; }
}