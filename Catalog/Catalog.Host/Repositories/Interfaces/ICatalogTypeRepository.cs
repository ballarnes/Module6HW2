using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<int> AddType(string type);
    Task<string> RemoveType(int id);
    Task<string> UpdateType(int id, string type);
}