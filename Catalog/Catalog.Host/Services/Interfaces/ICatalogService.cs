using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<CatalogItemDto> GetByIdAsync(int id);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetByBrandAsync(int pageSize, int pageIndex, string brand);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetByTypeAsync(int pageSize, int pageIndex, string type);
    Task<PaginatedItemsResponse<CatalogBrandDto>> GetBrandsAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogTypeDto>> GetTypesAsync(int pageSize, int pageIndex);
    Task<int> CreateProductAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<string> RemoveItem(int id);
    Task<string> UpdateItem(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<int> AddBrand(string brand);
    Task<string> RemoveBrand(int id);
    Task<string> UpdateBrand(int id, string brand);
    Task<int> AddType(string type);
    Task<string> RemoveType(int id);
    Task<string> UpdateType(int id, string type);
}