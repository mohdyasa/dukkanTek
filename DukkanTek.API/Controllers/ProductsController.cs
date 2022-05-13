using DukkanTek.Common;
using DukkanTek.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DukkanTek.API.Controllers;
[Route("products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService service;
    private readonly ILogger<ProductsController> logger;

    public ProductsController(IProductService service, ILogger<ProductsController> logger)
    {
        this.service = service;
        this.logger = logger;
    }

    [HttpGet("data")]
    public async Task<IActionResult> GetProductData()
    {
        try
        {
            return Ok(await service.GetAsync());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(ProductsController));
            return Conflict("Unable to fetch records");
        }
    }

    [HttpGet("{id}/{status}")]
    public async Task<IActionResult> UpdatePrpductStatus(string id, string status)
    {
        try
        {
            return Ok(await service.UpdateStatusAsync(id, status));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(ProductsController));
            return Conflict("Unable to fetch records");
        }
    }

    [HttpPost("{id}/{sell}")]
    public async Task<IActionResult> SellProduct(string id)
    {
        try
        {
            return Ok(await service.UpdateStatusAsync(id, ProductStatus.sold.ToString()));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, nameof(ProductsController));
            return Conflict("Unable to fetch records");
        }
    }

}

