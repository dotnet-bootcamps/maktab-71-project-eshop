using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.Product.Dtos;
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
        public async Task<IActionResult> GetBrands(string? name, int? id, CancellationToken cancellationToken)
        {
            var brands = await _brandAppService.GetBrands(name, id, cancellationToken);
            return Ok(brands);
        }


        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetBrand(string name,int displayOrder, CancellationToken cancellationToken)
        {
            await _brandAppService.Set(name,displayOrder);
            return Ok();
        }
    }
}
