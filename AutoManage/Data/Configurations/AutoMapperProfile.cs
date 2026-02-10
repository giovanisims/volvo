using AutoMapper;
using AutoManage.Models;
using AutoManage.Models.DTOs;

namespace AutoManage.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // DTO, Original model
        CreateMap<CreateVehicleDTO, Vehicle>();
    }
}