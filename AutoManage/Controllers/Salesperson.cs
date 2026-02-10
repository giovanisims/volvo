using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Models.DTOs;
using AutoManage.Services.Interfaces;
using AutoMapper;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class SalespeopleController(ISalespersonService service, IMapper mapper) : BaseController<Salesperson, CreateSalespersonDTO>(service, mapper)
{
    [HttpGet("Comission/{id}")]
    public async Task<IActionResult> FinalSalary(int id) => Ok(await service.FinalSalaryAsync(id));
}