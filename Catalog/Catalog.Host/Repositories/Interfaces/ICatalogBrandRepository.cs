using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<int> AddBrand(string brand);
    Task<string> RemoveBrand(int id);
    Task<string> UpdateBrand(int id, string brand);
}