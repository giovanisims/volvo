using System.Text.Json.Serialization;
namespace AutoManage.Models;

public class Accessory : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required int VehicleId { get; set; }

    [JsonIgnore]
    public Vehicle? Vehicle { get; set; }
}