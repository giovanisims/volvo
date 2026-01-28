using model.clientes;
using model.dto;
namespace service;

public class EnderecoService
{
    private readonly ClienteService _clienteService;

    // we need to insert cliente here since the address is created with Cliente
    public EnderecoService(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }
    public List<Endereco> GetTodos()
    {
        return _clienteService.GetTodos()
            .SelectMany(c => c.Enderecos)
            .ToList();
    }


}