using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;
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
            var permission = _permissionService.HasPermission(operatorId, (int)PermissionsEnum.ViewBrands);
            if (!permission)
            {
                throw new UnauthorizedAccessException();
            }
            var brands = _productService.GetAllBrands();
            return brands;
        }
        public List<Category> GetAllCategories(int operatorId)
        {
            var permission = _permissionService.HasPermission(operatorId, (int)PermissionsEnum.ViewCategories);
            if (!permission)
            {
                throw new UnauthorizedAccessException();
            }
            var categories = _productService.GetAllCategories();
            return categories;
        }

        public List<Core.Product.Entities.Product> GetAllProducts(int operatorId)
        {
            var permission = _permissionService.HasPermission(operatorId, (int)PermissionsEnum.ViewProducts);
            if (!permission)
            {
                throw new UnauthorizedAccessException();
            }
            var products = _productService.GetAllProducts();
            return products;
        }

        public List<Tag> GetAllTags(int operatorId)
        {
            var permission = _permissionService.HasPermission(operatorId, (int)PermissionsEnum.ViewTags);
            if (!permission)
            {
                throw new UnauthorizedAccessException();
            }
            var tags = _productService.GetAllTags();
            return tags;
        }
        public List<Model> GetAllModels(int operatorId)
        {
            var permission = _permissionService.HasPermission(operatorId, (int)PermissionsEnum.ViewModels);
            if (!permission)
            {
                throw new UnauthorizedAccessException();
            }
            var models = _productService.GetAllModels();
            return models;
        }

        public int CreateModel(Model model)
        {
            var id = _productService.CreateModel(model);
            return id;
        }

        public int CreateBrand(Brand model)
        {
            var id = _productService.CreateBrand(model);
            return id;
        }

        public int CreateCategory(Category model)
        {
            var id = _productService.CreateCategory(model);
            return id;
        }

        public int CreateTag(Tag model)
        {
            var id = _productService.CreateTag(model);
            return id;
        }

        public int CreateProduct(Core.Product.Entities.Product model)
        {
            var id = _productService.CreateProduct(model);
            return id;
        }

        public int UpdateModel(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
