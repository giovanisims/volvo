
namespace AutoManage.Model;

public class Sale
{
    public int Id {get;set;}

    public int VehicleId {get;set;}
    public Vehicle Vehicle {get;set;}

    public int SalespersonId {get;set;}
    public Salesperson Salesperson {get;set;}

    public DateTime SaleDate {get;set;}
    public decimal SalePrice {get;set;}
}

