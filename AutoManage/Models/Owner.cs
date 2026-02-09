
namespace AutoManage.Models;

public class Owner : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string CPF_CNPJ { get; set; }
    public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    public required string Email { get; set; }
    public required string Telephone { get; set; }
    // I'm not 100% sure what "DadosPessoais" means so I decided to instead implement these three attributes
    // "BirthDate" is useful for age checks and in a real world system targeted advertising
    // "CNH" is self-explanatory
    // "AdditionalInfo" is what I think DadosPessoais was supposed to mean which is just some info about a customer
    public DateTime? BirthDate { get; set; }
    public string? CNH { get; set; }
    public string? AdditionalInfo { get; set; }
}

