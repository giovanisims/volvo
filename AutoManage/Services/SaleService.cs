using AutoManage.Data;
using AutoManage.Models;
using Microsoft.EntityFrameworkCore;
using AutoManage.Services.Interfaces;

namespace AutoManage.Services;

public class SaleService(AppDbContext context) : BaseService<Sale>(context), ISaleService
{
    public override async Task<Sale> CreateAsync(Sale sale)
    {
        // This just runs some new checks and then uses the default create command since that alreay has the FKs
        var vehicleStatus = await _context.Vehicles
            .Where(v => v.Id == sale.VehicleId)
            .Select(v => new
            // projections are awesome, effectivelly this means that I'm returning the kinda JSON below temporarly
            {
                Exists = true,
                IsSold = _context.Sales.Any(s => s.VehicleId == v.Id)
            })
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Vehicle not found.");

        if (vehicleStatus.IsSold) throw new InvalidOperationException("This vehicle has already been sold!");
        
        return await base.CreateAsync(sale);
    }
}