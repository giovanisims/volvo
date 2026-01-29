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
    public List<Endereco> GetTodos() => _clienteService.GetTodos().SelectMany(c => c.Enderecos).ToList();

    public bool Adicionar(EnderecoDTO dto)
    {

        var cliente = _clienteService.GetPorLogin(dto.ClienteLogin);
        if (cliente == null) return false; 

        var endereco = new Endereco(
        dto.Rua, dto.Numero, dto.Complemento, 
        dto.Bairro, dto.Cidade, dto.Estado, dto.Cep
        );

        cliente.InserirEndereco(endereco);
        return true;
    }

}