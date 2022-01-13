using System.Net;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogService _catalogService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> CreateItem(CreateItemRequest request)
    {
        var result = await _catalogService.CreateProductAsync(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
        return Ok(new CreateResponse<int>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(EditResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveItem(GetByIdRequest request)
    {
        var result = await _catalogService.RemoveItem(request.Id);
        return Ok(new EditResponse() { Result = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(EditResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateItem(UpdateItemRequest request)
    {
        var result = await _catalogService.UpdateItem(request.Id, request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
        return Ok(new EditResponse() { Result = result });
    }
}