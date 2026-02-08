
using System.Data;
using AutoManage.Data;
using AutoManage.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Services;

public class AccessoryService(AppDbContext context) : IAccessoryService
{
    public async Task<IEnumerable<Accessory>> GetAllAsync() => await context.Accessories.ToListAsync();

    public async Task<Accessory?> GetByIdAsync(int id) => await context.Accessories.FindAsync(id);

    public async Task<Accessory> CreateAsync(Accessory accessory)
    {
        context.Accessories.Add(accessory);
        await context.SaveChangesAsync();
        return accessory;
    }

    public async Task<bool> UpdateAsync(int id, Accessory accessory)
    {
        if (id != accessory.Id) return false;
        context.Entry(accessory).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
            return true;
        }
        catch (DBConcurrencyException)
        {
            if (!context.Accessories.Any(a => a.Id == id)) return false;
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (await context.Accessories.FindAsync(id) is not Accessory accessory) return false;

        context.Accessories.Remove(accessory);
        await context.SaveChangesAsync();
        return true;
    }
}