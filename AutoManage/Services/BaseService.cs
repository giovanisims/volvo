using Microsoft.EntityFrameworkCore;
using AutoManage.Data;
using AutoManage.Models;

namespace AutoManage.Services;

public interface IBaseService<T> where T : class, IEntity
{
    // We use IEnumerable because it's just a readonly stream instead of a complicated List with methods
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(int id);
}

// Technically primary constructors are less safe since you cant make the "context" field readonly
// but they look 100 times better and just like dont overwrite the database context 
public class BaseService<T>(AppDbContext context) : IBaseService<T> where T : class, IEntity
{
    // Task is the async return type, it only handles basic threading mechanics, it doesn't even do timeouts
    public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);

    public async Task<T> CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, T entity)
    {
        // Good practice to check if there is a discrepancy between the user provided one and the object
        if (id != entity.Id) return false;

        /* At first "context" (the db connection) has never seen this specific object before, since
        it was created from the user's JSON, so we call "Entry()" so that "EF" starts tracking the object, 
        but it sees that it has the same id as another entity already in the database, so it assumes it's the
        same entity, which means "SaveChangesAsync()" wouldn't do anything, and we know that it's a different
        object, but we dont know what is different about it, so we change the "State" of the entire object 
        which makes "EF" think EVERYTHING has changed (instead of just the actually modified fields),
        and now when we save these changes it will rewrite the whole entry in the DB, which could be an issue 
        if, for example, the payload is missing a Date field since it would be replaced by the default date.
        
        However "blind updates" like this consume half the I/O, and are actually more REST compliant */
        context.Entry(entity).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
            return true;
        }
        // Edge case where entry gets deleted while being edited
        catch (DbUpdateConcurrencyException)
        {
            // This looks like a loop but it actually just this query 
            /* SELECT CASE
                    WHEN EXISTS (
                        SELECT 1
                        FROM [TableName]
                        WHERE Id = [id]
                    )
                    THEN CAST(1 AS BIT)
                    ELSE CAST(0 AS BIT)
                END
                Which is near instant */
            if (!await context.Set<T>().AnyAsync(e => e.Id == id)) return false;
            // If the entity was found and it STILL failed to update, might as well let it crash
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (await context.Set<T>().FindAsync(id) is not T entity) return false;

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}