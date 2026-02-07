
namespace AutoManage.Models;

public class Vehicle
{
    public int Id {get;set;}
    public required string Chassis {get;set;} // Unique field
    public required string Model {get;set;}
    public required int Year {get;set;}
    public required string Color {get;set;}
    public required decimal Value {get;set;}
    public required double Odometer {get;set;}
    // ICollection is preferred for EF realtionships, since a list implies an order (0,1,2,3), but that's not 
    // what's actually happening, in reality this is just a bag of unordered items so we use ICollection instead
    // It also enables using "HashSet" which is supposedly near instant and lazy loading
    public ICollection<Accessory> Accessories {get;set;} = new HashSet<Accessory>();
    public required string SystemVersion {get;set;}
    
    public required int OwnerId {get;set;}
    // This is a naviagation property
    // In a "one to many, in the "many" side you can add a field that's just an instance of the "one" object 
    // and that can allow for a lot of flexibility i.e. myVehicle.Owner.Name (This also works for "one to one")
    public Owner? Owner {get;set;} 
}
