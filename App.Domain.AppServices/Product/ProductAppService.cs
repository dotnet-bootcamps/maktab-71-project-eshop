using App.Domain.Core.Permission.Contarcts.Services;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IPermissionService _permissionService;

        public ProductAppService(IProductService productService, IPermissionService permissionService)
        {
            _productService = productService;
            _permissionService = permissionService;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _productService.GetProducts();
        }


        public async Task SetProduct(int categoryId, int brandId, decimal Weight, bool IsOrginal, string description,
            int count,
            int modelId, long price, int operatorId, bool isShowPrice, string name)
        {
            _permissionService.HasPermission(1, 5);
            _productService.EnsureProductDoseNotExist(name);
            await _productService.SetProduct(categoryId, brandId, Weight, IsOrginal, description, count, modelId, price,
                operatorId, isShowPrice, name);
        }

        public ProductDto GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }

        public ProductDto GetProduct(string name)
        {
            return _productService.GetProduct(name);
        }

        public void UpdateProduct(int id, int categoryId, int brandId, decimal Weight, bool IsOrginal,
            string description, int count,
            int modelId, long price, int operatorId, bool isShowPrice, string name)
        {
            _permissionService.HasPermission(1, 6);
            _productService.EnsureProductExist(id);
            _productService.UpdateProduct(id, categoryId, brandId, Weight, IsOrginal, description, count, modelId,
                price,
                operatorId, isShowPrice, name);
        }

        public void DeleteProduct(int id)
        {
            _permissionService.HasPermission(1, 7);
            _productService.EnsureProductExist(id);
            _productService.DeleteProduct(id);
        }
    }
}