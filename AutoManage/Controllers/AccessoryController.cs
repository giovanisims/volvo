using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccessoryController(IAccessoryService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Accessory accessory)
    {
        var createdAccessory = await service.CreateAsync(accessory);
        return CreatedAtAction(nameof(GetById), new { id = accessory.Id }, createdAccessory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Accessory accessory) =>
        await service.UpdateAsync(id, accessory) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}