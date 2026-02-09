using AutoManage.Models;

namespace AutoManage.Services;

public interface IVehicleService : IBaseService<Vehicle>
{
    // This name is probably too long
    Task<IEnumerable<Vehicle>> GetBySystemVersionOrderedByOdometerAsync(string version);
}