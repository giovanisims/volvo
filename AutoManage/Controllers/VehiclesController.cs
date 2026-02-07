using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoManage.Data;
using AutoManage.Model;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Technically primary constructors are less safe since you cant make the "context" field readonly
// but they look 100 times better and just like dont overwrite the database context 
public class VehiclesController(AppDbContext context) : ControllerBase
{
    // Task is the asyc return type, it only handles basic threading mechanics, it doesn't even do timeout 
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await context.Vehicles.ToListAsync();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (await context.Vehicles.FindAsync(id) is not Vehicle vehicle) return NotFound();
        return Ok(vehicle);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
        await context.SaveChangesAsync();
        /* We have no real front-end so it's technically unecessary to have a complex return like this
        But it would be best practice in the real world
        "nameof" kinda serves like "type safety" for the function name
        we need to assign vehicle.id to "id" because otherwise it's just a nameless variable for the router
        and then the third param just returns the relevant object */
        return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
    }

    [HttpPut("{id}")]
    // REST demands that the "id" is provided singularly, but could be implemented with the id from the body
    public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle)
    {
        // Good practice to check if there is a discrepancy between the user provided one and the object
        if (id != vehicle.Id) return BadRequest();

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

        try
        {
            await context.SaveChangesAsync();
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
            if (!context.Vehicles.Any(v => v.Id == id)) return NotFound();
            // If it's still there AND STILL failed to update, might as well let it crash
            throw;
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id)
    {
        if (await context.Vehicles.FindAsync(id) is not Vehicle vehicle) return NotFound();

        context.Vehicles.Remove(vehicle);
        await context.SaveChangesAsync();

        return NoContent();
    }
}