using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.BaseData
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandAppService _brandAppService;
        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }
        [HttpGet("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> GetBrand()
        {
            var products = await _brandAppService.GetAll();
            return Ok(products);
        }
        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetBrand(BrandDto brand, CancellationToken cancellationToken)
        {
            await _brandAppService.Set(brand.Name,brand.DisplayOrder);
            return Ok();
        }
    }
}
