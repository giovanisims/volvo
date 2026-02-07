using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController(IVehicleService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await service.GetAllAsync();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (await service.GetByIdAsync(id) is not Vehicle vehicle) return NotFound();
        return Ok(vehicle);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
    {

        var createdVehicle = await service.CreateAsync(vehicle);
        /* We have no real front-end so it's technically unecessary to have a complex return like this
        But it would be best practice in the real world
        "nameof" kinda serves like "type safety" for the function name
        we need to assign vehicle.id to "id" because otherwise it's just a nameless variable for the router
        and then the third param just returns the relevant object */
        return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
    }

    [HttpPut("{id}")]
    // REST demands that the "id" is provided singularly, but this could be implemented with the id from the body
    public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle)
    {
        // Good practice to check if there is a discrepancy between the user provided one and the object
        if (id != vehicle.Id) return BadRequest();
        if (!await service.UpdateAsync(id, vehicle)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id)
    {
        if (!await service.DeleteAsync(id)) return NotFound();
        return NoContent();
    }
}