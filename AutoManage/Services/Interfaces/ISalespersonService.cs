using AutoManage.Models;

namespace AutoManage.Services.Interfaces;

public interface ISalespersonService : IBaseService<Salesperson>
{
    Task<decimal> FinalSalaryAsync(int id);
}