
namespace AutoManage.Models;

public class Accessory
{
    public int Id {get;set;}
    public required string Name {get;set;}

    public required int VehicleId {get;set;}
    public Vehicle? Vehicle {get;set;}
}