using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoManage.Data;
using AutoManage.Models;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var address = context.Addresses.ToListAsync();
        return Ok(address);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (await context.Addresses.FindAsync(id) is not Address address) return NotFound();
        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Address address)
    {
        context.Addresses.Add(address);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = address.Id }, address);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Address address)
    {
        if (id != address.Id) return BadRequest();
        context.Entry(address).State = EntityState.Modified;

        try { await context.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.Addresses.Any(a => a.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await context.Addresses.FindAsync(id) is not Address address) return NotFound();
        context.Addresses.Remove(address);
        await context.SaveChangesAsync();
        return NoContent();
    }
}