using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.Brand
{
    //Brand Controler API
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
        public async Task<IActionResult> Index()
        {
            var brands = await _brandAppService.GetAll();
            return Ok(brands);
        }

        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetBrand(BrandDto brandDto, CancellationToken cancellationToken)
        {
            await _brandAppService.Set(brandDto.Name,brandDto.DisplayOrder);
            return Ok();
        }
    }
}
