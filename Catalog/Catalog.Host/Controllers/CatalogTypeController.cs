using System.Net;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogService _catalogService;

    public CatalogTypeController(
        ILogger<CatalogBrandController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddType(CreateTypeRequest request)
    {
        var result = await _catalogService.AddType(request.Type!);
        return Ok(new CreateResponse<int>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(EditResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> RemoveType(GetByIdRequest request)
    {
        var result = await _catalogService.RemoveType(request.Id);
        return Ok(new EditResponse() { Result = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(EditResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> UpdateType(UpdateTypeRequest request)
    {
        var result = await _catalogService.UpdateType(request.Id, request.Type);
        return Ok(new EditResponse() { Result = result });
    }
}