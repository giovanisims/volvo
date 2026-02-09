using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController<T>(IBaseService<T> service) : ControllerBase where T : class, IEntity
{
    [HttpGet]
    public virtual async Task<IActionResult> GetAll() => Ok(await service.GetAllAsync());

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(int id) =>
        await service.GetByIdAsync(id) is T entity ? Ok(entity) : NotFound();

    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] T entity)
    {
        var createdEntity = await service.CreateAsync(entity);
        
        /* We have no real front-end so it's technically unnecessary to have a complex return like this
        But it would be best practice in the real world. "nameof" kinda serves like "type safety" for 
        the function name, we need to assign entity.Id to "id" because otherwise it's just a nameless
        variable for the router and then the third param just returns the relevant object */
        return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);
    }

    [HttpPut("{id}")]
    // REST demands that the "id" is provided singularly, but this could be implemented with the id from the body
    public virtual async Task<IActionResult> Update(int id, [FromBody] T entity) =>
        await service.UpdateAsync(id, entity) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}