
namespace AutoManage.Models.DTOs;
public record CreateVehicleDTO(
    string Chassis,
    string Model,
    int Year,
    string Color,
    decimal Value,
    double Odometer,
    string SystemVersion,
    int OwnerId 
);