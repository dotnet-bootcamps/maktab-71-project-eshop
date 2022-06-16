using App.Domain.Core.Permission.Contracts.AppServices;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productSevice;
        private readonly IPermissionService _permissionService;
        public ProductAppService(
            IProductService productService,
            IPermissionService permissionService)
        {
            _productSevice = productService;
            _permissionService = permissionService;
        }
        public List<Brand> GetAllBrands(int operatorId)
        {
            if (!_permissionService.HasPermission(operatorId, (int)PermissionEnam.ViewBrand))
                throw new UnauthorizedAccessException("This operator has not permission to view brands");
            return _productSevice.GetAllBrands();
        }
    }
}
