using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.Product
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
        public async Task<IActionResult> GetBrands()
        {
            var Brands = await _brandAppService.GetAll();
            return Ok(Brands);
        }
        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetBrand(BrandBriefDto brandBriefDto)
        {
            await _brandAppService.Set(brandBriefDto.Name, brandBriefDto.DisplayOrder);
            return Ok();
        }
    }
}
