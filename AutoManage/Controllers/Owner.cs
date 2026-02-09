using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Services.Interfaces;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class OwnersController(IBaseService<Owner> service) : BaseController<Owner>(service);