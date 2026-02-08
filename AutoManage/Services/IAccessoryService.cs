using AutoManage.Models;

namespace AutoManage.Services;

public interface IAccessoryService
{
    // We use IEnumerable becase it's just a readonly stream insted of a complicated List with methods
    Task<IEnumerable<Accessory>> GetAllAsync();
    Task<Accessory?> GetByIdAsync(int id);
    Task<Accessory> CreateAsync(Accessory vehicle);
    Task<bool> UpdateAsync(int id, Accessory vehicle);
    Task<bool> DeleteAsync(int id);
}