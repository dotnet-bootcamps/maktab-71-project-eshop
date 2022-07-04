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

        [HttpGet]
        [ApiKeyAuthorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _brandAppService.GetAll());
        }

        [HttpPost]
        [ApiKeyAuthorize]
        public async Task<IActionResult> Post(string name, int displayOrder, CancellationToken cancellationToken)
        {
            await _brandAppService.Set(name, displayOrder);
            return Ok();
        }
    }
}
