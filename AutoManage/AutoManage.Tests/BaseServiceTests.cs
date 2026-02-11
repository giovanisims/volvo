using AutoManage.Data;
using AutoManage.Models;
using AutoManage.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoManage.Tests;

public abstract class BaseServiceTests<TEntity> where TEntity : class, IEntity
{
    protected AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    protected abstract IBaseService<TEntity> CreateService(AppDbContext context);
    protected abstract TEntity CreateSampleEntity(int id);

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        // Arrange
        using var context = GetDbContext();
        var service = CreateService(context);
        
        var entity1 = CreateSampleEntity(1);
        var entity2 = CreateSampleEntity(2);
        
        context.Set<TEntity>().AddRange(entity1, entity2);
        await context.SaveChangesAsync();

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEntity_WhenExists()
    {
        // Arrange
        using var context = GetDbContext();
        var service = CreateService(context);
        
        var entity = CreateSampleEntity(1);
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();

        // Act
        var result = await service.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenDoesNotExist()
    {
        // Arrange
        using var context = GetDbContext();
        var service = CreateService(context);

        // Act
        var result = await service.GetByIdAsync(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddEntity()
    {
        // Arrange
        using var context = GetDbContext();
        var service = CreateService(context);
        var entity = CreateSampleEntity(1);

        // Act
        var result = await service.CreateAsync(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        
        var savedEntity = await context.Set<TEntity>().FindAsync(1);
        Assert.NotNull(savedEntity);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntity_WhenExists()
    {
        // Arrange
        using var context = GetDbContext();
        var service = CreateService(context);
        
        var entity = CreateSampleEntity(1);
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();

        // Modify entity (detached logic simulation often needed, but InMemory tracks objects. 
        // For UpdateAsync in BaseService to work with EntityState.Modified, we often need to be careful with tracking.)
        // BaseService.UpdateAsync uses: _context.Entry(entity).State = EntityState.Modified;
        
        // Ensure we are working with a 'new' object ref or same ref?
        // If we pass the SAME object instance that is already tracked, setting State=Modified is fine.
        // If we want to simulate an API request where we get a NEW object with the same ID:
        
        context.ChangeTracker.Clear(); // Clear tracking to simulate a fresh request context

        var updatedEntity = CreateSampleEntity(1);
        // Change a property if possible? Generic TEntity doesn't expose props besides Id. 
        // But UpdateAsync generally just checks ID match and updates DB.
        
        // Act
        var result = await service.UpdateAsync(1, updatedEntity);

        // Assert
        Assert.True(result);
        
        var savedEntity = await context.Set<TEntity>().FindAsync(1);
        Assert.NotNull(savedEntity);
    }
}
