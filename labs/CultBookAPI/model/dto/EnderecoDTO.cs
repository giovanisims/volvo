namespace model.dto;

public class EnderecoDTO
{
    public string ClienteLogin { get; set; } 
    public string Rua { get; set; } 
    public int Numero { get; set; }
    public string Complemento { get; set; } = null;
    public string Bairro { get; set; } 
    public string Cidade { get; set; } 
    public string Estado { get; set; } 
    public string Cep { get; set; } 
}