using Microsoft.AspNetCore.Mvc;
using model.clientes;
using service;
using model.dto;

namespace controller.api;

[ApiController] 
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService; 
    private readonly ServicoAutenticacao _autenticacaoService;

    public ClienteController(ClienteService clientService, ServicoAutenticacao authService)
    {
        _clienteService = clientService; 
        _autenticacaoService = authService;
    }

    // For testing purposes only
    [HttpGet]
    public IActionResult BuscarClientes() => Ok(_clienteService.GetTodos());
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO data)
    {
        var usuario = _clienteService.GetPorLogin(data.Login);

        if (usuario == null) 
            return NotFound(new { message = "Usuário não existe" });


        bool sucesso = _autenticacaoService.ValidarLogin(usuario, data.Password);

        if (sucesso)
        {
            return Ok(new { message = $"Bem vindo {usuario.Login}!" });
        }

        return Unauthorized(new { message = "Senha incorreta" });
    
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDTO data)
    {
        string senhaFinal = _clienteService.GerarSenhaSeVazia(data.Password);
        
        var endereco = new Endereco(data.Rua, data.Numero, data.Complemento, data.Bairro, data.Cidade, data.Estado, data.Cep);
        var novoCliente = new Cliente(data.Nome, data.Login, senhaFinal, data.Email, data.Fone, endereco);

        _clienteService.AdicionarCliente(novoCliente);
        
        return CreatedAtAction(nameof(Login), new { }, new { 
            message = "Usuário cadastrado com sucesso!", 
            login = novoCliente.Login,
            passwordUsed = (string.IsNullOrWhiteSpace(data.Password) ? senhaFinal : "Provided by user")
        });
    }
}