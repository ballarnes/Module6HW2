using System.Net;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogService _catalogService;

    public CatalogBrandController(
        ILogger<CatalogBrandController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddBrand(CreateBrandRequest request)
    {
        var result = await _catalogService.AddBrand(request.Brand!);
        return Ok(new CreateResponse<int>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(EditResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveBrand(GetByIdRequest request)
    {
        var result = await _catalogService.RemoveBrand(request.Id);
        return Ok(new EditResponse() { Result = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(EditResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateBrand(UpdateBrandRequest request)
    {
        var result = await _catalogService.UpdateBrand(request.Id, request.Brand);
        return Ok(new EditResponse() { Result = result });
    }
}