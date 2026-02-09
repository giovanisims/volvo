using System.Text.Json.Serialization;
namespace AutoManage.Models;

public class Address : IEntity
{
    public int Id { get; set; }
    public required string CEP { get; set; }
    public required string State { get; set; }
    public required string City { get; set; }
    public required string Neighborhood { get; set; }
    public required string Street { get; set; }
    public required string Number { get; set; }
    public string? Complement { get; set; }

    public required int OwnerId { get; set; }

    [JsonIgnore]
    public Owner? Owner { get; set; }
}