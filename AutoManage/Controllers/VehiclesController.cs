using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class VehiclesController(IBaseService<Vehicle> service) : BaseController<Vehicle>(service);