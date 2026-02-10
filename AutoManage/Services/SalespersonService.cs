using AutoManage.Data;
using AutoManage.Models;
using Microsoft.EntityFrameworkCore;
using AutoManage.Services.Interfaces;

namespace AutoManage.Services;

public class SalespersonService(AppDbContext context) : BaseService<Salesperson>(context), ISalespersonService
{
    public async Task<decimal> FinalSalaryAsync(int id) => 
        await _context.Salespeople
            .Where(s => s.Id == id)
            .Select(s => (decimal?)(s.Salary + (s.Sales
                .Where(sale => sale.SaleDate.Month == DateTime.Now.Month && sale.SaleDate.Year == DateTime.Now.Year)
                    .Sum(sale => sale.SalePrice) * 0.01m)))
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Salesperson not found");
}