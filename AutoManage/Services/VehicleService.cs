using AutoManage.Data;
using AutoManage.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Services;

public class VehicleService(AppDbContext context) : BaseService<Vehicle>(context), IVehicleService
{
    public async Task<IEnumerable<Vehicle>> GetBySystemVersionOrderedByOdometerAsync(string version)
    {
        return await _context.Vehicles
            .Where(v => v.SystemVersion == version)
            .OrderBy(v => v.Odometer)
            .ToListAsync();
    }
}