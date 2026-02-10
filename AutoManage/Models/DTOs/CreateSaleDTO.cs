namespace AutoManage.Models.DTOs;

public record CreateSaleDTO(
    int VehicleId,
    int SalespersonId,
    DateTime SaleDate,
    decimal SalePrice
);
