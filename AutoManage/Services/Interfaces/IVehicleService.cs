using AutoManage.Models;

namespace AutoManage.Services.Interfaces;

public interface IVehicleService : IBaseService<Vehicle>
{
    // This name is probably too long
    Task<IEnumerable<Vehicle>> GetBySystemVersionOrderedByOdometerAsync(string version);
}