using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }
        public List<Brand> GetAllBrands()
        {
            return _productService.GetAllBrands();
        }
    }
}
