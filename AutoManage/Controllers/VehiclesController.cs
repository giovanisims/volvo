using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Models.DTOs;
using AutoManage.Services.Interfaces;
using AutoMapper;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class VehiclesController(IVehicleService service, IMapper mapper) : BaseController<Vehicle>(service)
{
    [HttpGet("{id}")]
    public override async Task<IActionResult> GetById(int id) => Ok(await service.GetByIdAsync(id, "Owner"));

    [HttpPost]
    public async Task<IActionResult?> Create([FromBody] CreateVehicleDTO dto)
    {
        var vehicle = mapper.Map<Vehicle>(dto);

        var createdVehicle = await service.CreateAsync(vehicle);
        return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
    }

    [NonAction]
    public override Task<IActionResult> Create(Vehicle vehicle) =>
        throw new NotImplementedException("Use the DTO Create method instead.");

    [HttpGet("system/{version}")]
    public async Task<IActionResult> GetBySystemVersion(string version) =>
        Ok(await service.GetBySystemVersionOrderedByOdometerAsync(version));
}