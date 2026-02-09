using System.Text.Json.Serialization;
namespace AutoManage.Models;

public class Sale : IEntity
{
    public int Id { get; set; }

    public required int VehicleId { get; set; }
    [JsonIgnore]
    public Vehicle? Vehicle { get; set; }

    public required int SalespersonId { get; set; }

    [JsonIgnore]
    public Salesperson? Salesperson { get; set; }

    public required DateTime SaleDate { get; set; }
    public required decimal SalePrice { get; set; }
}