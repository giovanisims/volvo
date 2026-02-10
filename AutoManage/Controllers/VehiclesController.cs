using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Models.DTOs;
using AutoManage.Services.Interfaces;
using AutoMapper;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class VehiclesController(IVehicleService service, IMapper mapper) 
    : BaseController<Vehicle, CreateVehicleDTO>(service, mapper)
{
    [HttpGet("{id}")]
    public override async Task<IActionResult> GetById(int id) => Ok(await service.GetByIdAsync(id, "Owner"));

    [HttpGet("system/{version}")]
    public async Task<IActionResult> GetBySystemVersion(string version) =>
        Ok(await service.GetBySystemVersionOrderedByOdometerAsync(version));
}