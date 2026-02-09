using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services.Interfaces;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class VehiclesController(IVehicleService service) : BaseController<Vehicle>(service)
{
    [HttpGet("system/{version}")]
    public async Task<IActionResult> GetBySystemVersion(string version)
    {
        return Ok(await service.GetBySystemVersionOrderedByOdometerAsync(version));
    }
}