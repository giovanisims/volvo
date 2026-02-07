using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoManage.Data;
using AutoManage.Models;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccessoryController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accessories = await context.Accessories.ToListAsync();
        return Ok(accessories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (await context.Accessories.FindAsync(id) is not Accessory accessory) return NotFound();
        return Ok(accessory);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Accessory accessory)
    {
        context.Accessories.Add(accessory);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = accessory.Id }, accessory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Accessory accessory)
    {
        if (id != accessory.Id) return BadRequest();
        context.Entry(accessory).State = EntityState.Modified;

        try { await context.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.Accessories.Any(a => a.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await context.Accessories.FindAsync(id) is not Accessory accessory) return NotFound();
        context.Accessories.Remove(accessory);
        await context.SaveChangesAsync();
        return NoContent();
    }
}