
namespace AutoManage.Models;

public class Sale
{
    public int Id {get;set;}

    public required int VehicleId {get;set;}
    public Vehicle? Vehicle {get;set;}

    public required int SalespersonId {get;set;}
    public Salesperson? Salesperson {get;set;}

    public required DateTime SaleDate {get;set;}
    public required decimal SalePrice {get;set;}
}

