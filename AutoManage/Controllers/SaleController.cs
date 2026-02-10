using Microsoft.AspNetCore.Mvc;
using AutoManage.Models;
using AutoManage.Models.DTOs;
using AutoManage.Services.Interfaces;
using AutoMapper;

namespace AutoManage.Controllers;

[ApiController]
[Route("api/[controller]")]
// Inherits all HTTP methods automatically
public class SalesController(IBaseService<Sale> service, IMapper mapper) : BaseController<Sale, CreateSaleDTO>(service, mapper);