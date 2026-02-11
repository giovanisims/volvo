using AutoManage.Data;
using AutoManage.Models;
using AutoManage.Services;
using AutoManage.Services.Interfaces;

namespace AutoManage.Tests;

public class VehicleServiceTests : BaseServiceTests<Vehicle>
{
    protected override IBaseService<Vehicle> CreateService(AppDbContext context)
    {
        return new VehicleService(context);
    }

    protected override Vehicle CreateSampleEntity(int id)
    {
        return new Vehicle
        {
            Id = id,
            Chassis = $"CH{id}",
            Model = "XC40",
            Year = 2023,
            Color = "Black",
            Value = 50000m,
            Odometer = 1000 * id,
            SystemVersion = "2.0",
            OwnerId = 1
        };
    }

    // Custom Tests for VehicleService specific methods

    [Fact]
    public async Task GetBySystemVersionOrderedByOdometerAsync_ShouldReturnMatchingVehicles_OrderedByOdometer()
    {
        // Arrange
        using var context = GetDbContext();
        var service = (VehicleService)CreateService(context);
        var systemVersion = "2.0";

        var vehicles = new List<Vehicle>
        {
            new Vehicle { Id = 1, Chassis = "CH1", Model = "XC40", Year = 2023, Color = "Black", Value = 50000m, Odometer = 5000, SystemVersion = systemVersion, OwnerId = 1 },
            new Vehicle { Id = 2, Chassis = "CH2", Model = "XC60", Year = 2023, Color = "White", Value = 60000m, Odometer = 1000, SystemVersion = systemVersion, OwnerId = 1 },
            new Vehicle { Id = 3, Chassis = "CH3", Model = "XC90", Year = 2023, Color = "Grey", Value = 80000m, Odometer = 3000, SystemVersion = systemVersion, OwnerId = 1 },
            new Vehicle { Id = 4, Chassis = "CH4", Model = "C40", Year = 2023, Color = "Blue", Value = 55000m, Odometer = 2000, SystemVersion = "1.0", OwnerId = 1 }
        };

        context.Vehicles.AddRange(vehicles);
        await context.SaveChangesAsync();

        // Act
        var result = await service.GetBySystemVersionOrderedByOdometerAsync(systemVersion);
        var resultList = result.ToList();

        // Assert
        Assert.Equal(3, resultList.Count);
        
        // Verify Order: 1000 -> 3000 -> 5000
        Assert.Equal(1000, resultList[0].Odometer);
        Assert.Equal(3000, resultList[1].Odometer);
        Assert.Equal(5000, resultList[2].Odometer);
        
        // Verify System Version matches
        Assert.All(resultList, v => Assert.Equal(systemVersion, v.SystemVersion));
    }
}
