using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController(IVehicleService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) =>
        await service.GetByIdAsync(id) is Vehicle vehicle ? Ok(vehicle) : NotFound();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
    {
        var createdVehicle = await service.CreateAsync(vehicle);
        /* We have no real front-end so it's technically unecessary to have a complex return like this
        But it would be best practice in the real world. "nameof" kinda serves like "type safety" for 
        the function name, we need to assign vehicle.id to "id" because otherwise it's just a nameless
        variable for the router and then the third param just returns the relevant object */
        return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
    }

    [HttpPut("{id}")]
    // REST demands that the "id" is provided singularly, but this could be implemented with the id from the body
    public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle) =>
        await service.UpdateAsync(id, vehicle) ? NoContent() : NotFound();

    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}