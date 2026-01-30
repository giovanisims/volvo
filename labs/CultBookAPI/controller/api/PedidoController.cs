using Microsoft.AspNetCore.Mvc;
using model.livros;
using service;
using model.dto;

namespace controller.api;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidoController(PedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public IActionResult BuscarPedidos() => Ok(_pedidoService.GetTodos());
    
    [HttpPost]
    public IActionResult Adicionar([FromBody] PedidoDTO dto)
    {
        var sucesso = _pedidoService.Adicionar(dto);
        if (sucesso) return Ok(new { message = "Pedido realizado com sucesso." });
        
        return BadRequest(new { message = "Falha ao realizar pedido. Verifique se o cliente existe, se os ISBNs estão corretos ou se a lista de itens está vazia." });
    }

    // Keep in mind this method doesn't remove or move the old orders to a different place 
    // like you would on a normal system it just changes their "situacao" tag to "finalizado" and updates stock
    [HttpPost("FinalizarCompra")]
    public IActionResult FinalizarCompra([FromBody] FinalizarPedidoDTO dto)
    {
        var sucesso = _pedidoService.FinalizarCompra(dto);
        if (sucesso) return Ok(new { message = "Compra finalizada com sucesso." });
        
        return BadRequest(new { message = "Falha ao finalizar compra." });
    }

}


