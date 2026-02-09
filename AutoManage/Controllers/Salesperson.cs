using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services.Interfaces;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class SalespeopleController(ISalespersonService service) : BaseController<Salesperson>(service)
{
    [HttpGet("Comission/{id}")]
    public async Task<IActionResult> FinalSalary(int id) => Ok(await service.FinalSalaryAsync(id));
}