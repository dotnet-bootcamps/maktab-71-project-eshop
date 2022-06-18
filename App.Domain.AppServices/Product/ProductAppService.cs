using App.Domain.Core.Permission.Contracts.AppServices;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productSevice;
        private readonly IPermissionService _permissionService;
        private readonly IProductSurenessService _productSurenessService;

        public ProductAppService(
            IProductService productService,
            IPermissionService permissionService,
            IProductSurenessService productSurenessService)
        {
            _productSevice = productService;
            _permissionService = permissionService;
            _productSurenessService = productSurenessService;
        }
        public List<BrandDto> GetAllBrands(int operatorId)
        {
            if (!_permissionService.HasPermission(operatorId, (int)PermissionEnam.ViewBrand))
                throw new UnauthorizedAccessException("This operator has not permission to view brands");
            return _productSevice.GetAllBrands();
        }
        public void CreateBrand(Brand brand)
        {
            _productSurenessService.EnsureBrandIsNotExists(brand.Name);
            _productSevice.CreateBrand(brand);
        }
    }
}
