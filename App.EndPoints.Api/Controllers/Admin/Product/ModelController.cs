using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.Product
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ModelController : ControllerBase
    {
        private readonly IModelAppService _modelAppService;

        public ModelController(IModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetModels()
        {
            var models =await _modelAppService.GetAll();
            return Ok(models);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SetModel(ModelDto model)
        {
            await _modelAppService.Set(model);
            return Ok();
        }
    }
}
