using model.clientes;
using model.pedidos;
using model.livros;
using model.dto;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace service;

public class PedidoService
{
    private readonly ClienteService _clienteService;
    private readonly LivroService _livroService;

    public PedidoService(ClienteService clienteService, LivroService livroService)
    {
        _clienteService = clienteService;
        _livroService = livroService;
    }

    public List<Pedido> GetTodos() => _clienteService.GetTodos().SelectMany(c => c.Pedidos).ToList();

    public bool Adicionar(PedidoDTO dto)
    {
        var cliente = _clienteService.GetPorLogin(dto.ClienteLogin);
        if (cliente == null || dto.Itens.Count == 0) return false;

        var itens = new List<ItemDePedido>();
        foreach (var item in dto.Itens)
        {
            var livro = _livroService.GetModelPorIsbn(item.Isbn);
            if (livro == null) return false;

            itens.Add(new ItemDePedido(livro, item.Qtde, livro.Preco));
        }

        // Constructor requires the first item
        var novoPedido = new Pedido(
            dto.NumeroPedido,
            dto.DataEmissao,
            dto.FormaPagamento,
            dto.Situacao,
            itens[0]
        );

        for (int i = 1; i < itens.Count; i++)
        {
            novoPedido.InserirItem(itens[i]);
        }

        return cliente.InserirPedido(novoPedido);
    }
}