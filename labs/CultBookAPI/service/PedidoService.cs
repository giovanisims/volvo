using model.clientes;
using model.pedidos;
using model.livros;
using model.dto;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace service;

public class PedidoService
{
    private readonly ClienteService _clienteService;
    private readonly LivroService _livroService;
    private int _proximoNumero = 1;

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

        // Look for an existing order for this client that is still "aberto"
        var pedidoExistente = cliente.Pedidos.FirstOrDefault(p => 
            p.Situacao.Equals("aberto", StringComparison.OrdinalIgnoreCase));

        if (pedidoExistente != null)
        {
            foreach (var itemDto in dto.Itens)
            {
                var livro = _livroService.GetModelPorIsbn(itemDto.Isbn);
                if (livro == null) return false;
                pedidoExistente.InserirItem(new ItemDePedido(livro, itemDto.Qtde, livro.Preco));
            }
            return true;
        }

        // If no "aberto" order exists, create a new one
        var itens = new List<ItemDePedido>();
        foreach (var itemDto in dto.Itens)
        {
            var livro = _livroService.GetModelPorIsbn(itemDto.Isbn);
            if (livro == null) return false;
            itens.Add(new ItemDePedido(livro, itemDto.Qtde, livro.Preco));
        }

        var novoPedido = new Pedido(
            _proximoNumero++,
            dto.DataEmissao,
            dto.FormaPagamento,
            dto.Situacao, // This should be "aberto" in the DTO for new orders
            itens[0]
        );

        for (int i = 1; i < itens.Count; i++)
        {
            novoPedido.InserirItem(itens[i]);
        }

        return cliente.InserirPedido(novoPedido);
    }
}