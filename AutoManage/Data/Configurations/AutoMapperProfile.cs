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
        CreateMap<CreateAccessoryDTO, Accessory>();
        CreateMap<CreateAddressDTO, Address>();
        CreateMap<CreateOwnerDTO, Owner>();
        CreateMap<CreateSaleDTO, Sale>();
        CreateMap<CreateSalespersonDTO, Salesperson>();
    }
}