using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.BaseData
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        [HttpGet("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> GetBrands(int? brandId, string? brandName, CancellationToken cancellationToken)
        {
            var brands = await _brandAppService.GetBrands(brandId,brandName,cancellationToken);
            return Ok(brands);
        }

        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetBrand(BrandDto brand)
        {
            await _brandAppService.Set(brand.Name , brand.DisplayOrder);
            return Ok();
        }
    }
}
