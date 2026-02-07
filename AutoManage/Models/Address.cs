
namespace AutoManage.Models;

public class Address
{
    public int Id {get;set;}
    public required string CEP {get;set;}
    public required string State {get;set;}
    public required string City {get;set;}
    public required string Neighborhood {get;set;}
    public required string Street {get;set;}
    public required string Number {get;set;}
    public string? Complement {get;set;}

    public required int OwnerId {get;set;}
    public Owner? Owner {get;set;}
}