using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IPermissionService _permissionService;

        public ProductAppService(IProductService productService
            , IPermissionService permissionService)
        {
            _productService = productService;
            _permissionService = permissionService;
        }
        public async Task<int> Create(ProductInputDto product, int operatorId)
        {
            await _productService.EnsureProductIsNotExist(product.Name, product.BrandId, product.CategoryId, product.ModelId);
            var id =await _productService.Create(product, operatorId);
            return id;
        }

        public async Task Delete(int id)
        {
            await _productService.EnsureProductIsExist(id);
            await _productService.Delete(id);
        }

        public async Task<ProductDto> Get(int id)
        {
            await _productService.EnsureProductIsExist(id);
            var product = await _productService.Get(id);
            return product;
        }

        public Task<ProductDto> Get(string name, int brandId, int categoryId, int modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAll()
        {
            await _permissionService.HasPermission(10, (int)PermissionsEnum.ViewProducts);
            var products = await _productService.GetAll();
            return products;
        }

        public async Task Update(ProductUpdateDto product)
        {
            await _productService.EnsureProductIsExist(product.Id);
            await _productService.Update(product);
        }
    }
}
