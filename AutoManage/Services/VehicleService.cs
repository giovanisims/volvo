using Microsoft.EntityFrameworkCore;
using AutoManage.Data;
using AutoManage.Models;

namespace AutoManage.Services;

// Technically primary constructors are less safe since you cant make the "context" field readonly
// but they look 100 times better and just like dont overwrite the database context 
public class VehicleService(AppDbContext context) : IVehicleService
{
    // Task is the asyc return type, it only handles basic threading mechanics, it doesn't even do timeouts
    public async Task<IEnumerable<Vehicle>> GetAllAsync() => await context.Vehicles.ToListAsync();
    public async Task<Vehicle?> GetByIdAsync(int id) => await context.Vehicles.FindAsync(id);

    public async Task<Vehicle> CreateAsync(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<bool> UpdateAsync(int id, Vehicle vehicle)
    {
        /* At first "context" (the db connection) has never seen this specific vehicle object before, since
        it was created from the user's JSON, so we call "Entry()" so that "EF" starts tracking the object, 
        but it sees that it has the same id as another vehicle already in the database, so it assumes it's the
        same entity, which means "SaveChangesAsync()" wouldn't do anything, and we know that it's a different
        object, but we dont know what is different about it, so we change the "State" of the entire object 
        which makes "EF" think EVERYTHING has changed (instead of just the actually modified fields),
        and now when we save these changes it will rewrite the whole entry in the DB, which could be an issue 
        if, for example, the payload is missing a Date field since it would be replaced by the default date.
        
        However "blind updates" like this consume half the I/O, and are actually more REST compliant */
        context.Entry(vehicle).State = EntityState.Modified;

        try {
            await context.SaveChangesAsync();
            return true;
            }
        // Edge case where entry gets deleted while being edited
        catch (DbUpdateConcurrencyException)
        {
            // This looks like a loop but it actually just this query 
            /* SELECT CASE
                    WHEN EXISTS (
                        SELECT 1
                        FROM Vehicles
                        WHERE Id = 55
                    )
                    THEN CAST(1 AS BIT)
                    ELSE CAST(0 AS BIT)
                END
                Which is near instant */
            if (!context.Vehicles.Any(v => v.Id == id)) return false;
            // If the entity was found and it STILL failed to update, might as well let it crash
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (await context.Vehicles.FindAsync(id) is not Vehicle vehicle) return false;

        context.Vehicles.Remove(vehicle);
        await context.SaveChangesAsync();
        return true;
    }
}