using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Dtos;
using App.EndPoints.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Controllers.Admin.Product
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IModelAppService _modelAppService;
        

        public ProductController(IProductAppService productAppService, IModelAppService ModelAppServic)
        {
            _productAppService = productAppService;
            _modelAppService = ModelAppServic;
            
        }
        [HttpGet("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> GetProducts(int? categoryId, string? keyword, int? minPrice, int? maxPrice, int? brandId, CancellationToken cancellationToken)
        {
            var products = await _productAppService.GetProducts(categoryId, keyword, minPrice, maxPrice, brandId, cancellationToken);
            return Ok(products);
        }

     

        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetProduct(ProductDto product,CancellationToken cancellationToken)
        {
            await _productAppService.Set(product);
            return Ok();
        }

        [HttpGet("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> GetAllModel()
        {
            var records = await _modelAppService.GetAll();
            return Ok(records);

        }
        [HttpPost("[action]")]
        [ApiKeyAuthorize]
        public async Task<IActionResult> SetModel(ProductDto product, CancellationToken cancellationToken)
        {
            await _productAppService.Set(product);
            return Ok();
        }

    }
}
