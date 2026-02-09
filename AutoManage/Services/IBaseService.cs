using AutoManage.Models;

namespace AutoManage.Services;

// "T" is a "Type parameter" that acts as a variable for the class names, ": class, IEntity" "class" means that "T"
// is a "Reference Type" which means that it can be ANY class, and then IEntity means that that class
// must also be inheriting from IEntity (since it's an interface it's actually implemementing in this case) 
public interface IBaseService<T> where T : class, IEntity
{
    // We use IEnumerable because it's just a readonly stream instead of a complicated List with methods
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(int id);
}
