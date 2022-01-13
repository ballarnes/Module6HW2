using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int> AddType(string type)
    {
        var newType = _dbContext.CatalogTypes.Add(new CatalogType
        {
            Type = type
        });

        await _dbContext.SaveChangesAsync();

        return newType.Entity.Id;
    }

    public async Task<string> RemoveType(int id)
    {
        var type = await _dbContext.CatalogTypes.Where(c => c.Id == id).FirstAsync();
        _dbContext.CatalogTypes.Remove(type);

        await _dbContext.SaveChangesAsync();

        return $"Successfully deleted. ({DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss")})";
    }

    public async Task<string> UpdateType(int id, string type)
    {
        var typeFromDb = await _dbContext.CatalogTypes.Where(i => i.Id == id).FirstAsync();
        typeFromDb.Type = type;
        _dbContext.CatalogTypes.Update(typeFromDb);

        await _dbContext.SaveChangesAsync();

        return $"Successfully updated. ({DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss")})";
    }
}