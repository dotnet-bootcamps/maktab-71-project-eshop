using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.Product
{
    [ApiController]
    [Route("api/[controller]")]

    public class ModelController : ControllerBase
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
            var products = await _modelAppService.GetAll();
            return Ok(products);
        }

        [HttpGet("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> GetModelBy(string name)
        {
            var products = await _modelAppService.Get(name);
            return Ok(products);
        }

        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetModel(ModelDto model, CancellationToken cancellationToken)
        {
            await _modelAppService.Set(model);
            return Ok();
        }

    }
}
