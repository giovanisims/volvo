
namespace AutoManage.Model;

public class Vehicle
{
    public int Id {get;set;}
    public string Chassis {get;set;} // Unique field
    public string Model {get;set;}
    public int Year {get;set;}
    public string Color {get;set;}
    public decimal Value {get;set;}
    public double Odometer {get;set;}
    public List<Accessory> Accessories {get;set;}
    public string SystemVersion {get;set;}
    
    public int OwnerId {get;set;}
    // This is a naviagation property
    // In a "one to many, in the "many" side you can add a field that's just an instance of the "one" object 
    // and that can allow for a lot of flexibility i.e. myVehicle.Owner.Name (This also works for "one to one")
    public Owner Owner {get;set;} 
}
