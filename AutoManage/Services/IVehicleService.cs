using AutoManage.Models;

namespace AutoManage.Services;

public interface IVehicleService
{
    // We use IEnumerable becase it's just a readonly stream insted of a complicated List with methods
    Task<IEnumerable<Vehicle>> GetAllAsync();
    Task<Vehicle?> GetByIdAsync(int id);
    Task<Vehicle> CreateAsync(Vehicle vehicle);
    Task<bool> UpdateAsync(int id, Vehicle vehicle);
    Task<bool> DeleteAsync(int id);
}