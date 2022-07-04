using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.Product
{
    [Route("api/[Controller]")]
    public class ModelController : Controller
    {
        private readonly IModelAppService _modelAppService;
        public ModelController(IModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }

        [HttpGet("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> GetModels()
        {
            return Ok(await _modelAppService.GetAll());
        }
        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetModel([FromBody]ModelDto record, CancellationToken cancellationToken)
        {
            await _modelAppService.Set(record);
            return Ok();
        }
    }
}
