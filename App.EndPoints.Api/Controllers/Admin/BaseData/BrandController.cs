using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.BaseData
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(await _brandAppService.GetAll());
        }

        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetBrand(BrandDto dto, CancellationToken cancellationToken)
        {
            await _brandAppService.Set(dto.Name, dto.DisplayOrder);
            return Ok();
        }
    }
}
