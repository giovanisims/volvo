using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services.Interfaces;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class AccessoriesController(IBaseService<Accessory> service) : BaseController<Accessory>(service);