
namespace AutoManage.Model;

public class Accessory
{
    public int Id {get;set;}
    public string Name {get;set;}

    public int VehicleId {get;set;}
    public Vehicle Vehicle {get;set;}
}