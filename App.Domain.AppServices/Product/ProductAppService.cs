using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IPermissionService _permissionService;
        private readonly IProductService _productService;

        public ProductAppService(IPermissionService permissionService,IProductService productService)
        {
            _permissionService = permissionService;
            _productService = productService;
        }
        public List<Brand> GetAllBrands(int operatorId)
        {
            var permission = _permissionService.HasPermission(operatorId, 12);
            if (!permission)
            {
                throw new UnauthorizedAccessException();
            }
            var brands = _productService.GetAllBrands();
            return brands;
        }
    }
}
