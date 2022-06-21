using App.Domain.Core.Permission.Contarcts.Services;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IPermissionService _permissionService;
        private readonly IProductService _productService;

        public ProductAppService(
            IPermissionService permissionService,
            IProductService productService)
        {
            _permissionService = permissionService;
            _productService = productService;
        }
        public async Task Add(ProductInputDto product)
        {
            await _permissionService.EnsureHasPermission(product.OperatorId, (int)PermissionsEnum.ViewProducts);
            await _productService.EnsureProductDoseNotExist(product.ModelId, product.CategoryId, product.BrandId);
            await _productService.Add(product);
        }

        public async Task Delete(int operatorId, int id)
        {
            await _permissionService.EnsureHasPermission(operatorId, (int)PermissionsEnum.RemoveProduct);
            await _productService.EnsureProductExists(id);
            await _productService.Remove(id);
        }

        public async Task<ProductOutputDto> Get(int operatorId, int id)
        {
            await _permissionService.EnsureHasPermission(operatorId, (int)PermissionsEnum.ViewProducts);
            await _productService.EnsureProductExists(id);
            return await _productService.Get(id);
        }

        public async Task<ProductOutputDto> Get(int operatorId, string name)
        {
            await _permissionService.EnsureHasPermission(operatorId, (int)PermissionsEnum.ViewProducts);
            await _productService.EnsureProductExists(name);
            return await _productService.Get(name);
        }

        public async Task<List<ProductOutputDto>> GetAll(int operatorId)
        {
            await _permissionService.EnsureHasPermission(operatorId, (int)PermissionsEnum.ViewProducts);
            return await _productService.GetAll();
        }

        public async Task Update(int id, ProductInputDto product, bool isDeleted)
        {
            await _permissionService.EnsureHasPermission(product.OperatorId, (int)PermissionsEnum.EditProduct);
            await _productService.EnsureProductExists(id);
            await _productService.Update(id, product, _productService.Get(id).Result.CreationDate, isDeleted);
        }
    }
}
