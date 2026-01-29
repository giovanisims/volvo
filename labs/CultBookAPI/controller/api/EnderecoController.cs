using Microsoft.AspNetCore.Mvc;
using model.livros;
using service;
using model.dto;

namespace controller.api;

[ApiController]
[Route("api/[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly EnderecoService _enderecoService;

    public EnderecoController(EnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public IActionResult BuscarEndderecos() => Ok(_enderecoService.GetTodos());

    [HttpPost]
    public IActionResult Adicionar([FromBody] EnderecoDTO dto)
    {
        if (!_enderecoService.Adicionar(dto))
        {
            return NotFound(new { message = "Cliente não encontrado" });
        }
        return Created("", new { message = "Endereço adicionado com sucesso!" });
    }
}