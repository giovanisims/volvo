using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class SalesController(IBaseService<Sale> service) : BaseController<Sale>(service);