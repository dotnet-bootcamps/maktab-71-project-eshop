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
        #region GetAllMethods
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
        #endregion

        #region CreateMethods
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


        #endregion

        #region UpdateMethods
        public void UpdateModel(Model model)
        {
            _productService.UpdateModel(model);
        }

        public void UpdateTag(Tag model)
        {
            _productService.UpdateTag(model);
        }

        public void UpdateCategory(Category model)
        {
            _productService.UpdateCategory(model);
        }

        public void UpdateBrand(Brand model)
        {
            _productService.UpdateBrand(model);
        }

        public void UpdateProduct(Core.Product.Entities.Product model)
        {
            _productService.UpdateProduct(model);
        }
        #endregion

        #region GetMethods
        public Model GetModelById(int id)
        {
            return _productService.GetModelById(id);
        }

        public Tag GetTagById(int id)
        {
            return _productService.GetTagById(id);
        }

        public Category GetCategoryById(int id)
        {
            return _productService.GetCategoryById(id);
        }

        public Brand GetBrandById(int id)
        {
            return _productService.GetBrandById(id);
        }

        public Core.Product.Entities.Product GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }

        #endregion

        #region RemoveMethods
        public bool RemoveModel(int id)
        {
            _productService.RemoveModel(id);
            return true;
        }

        public bool RemoveTag(int id)
        {
            _productService.RemoveTag(id);
            return true;
        }

        public bool RemoveBrand(int id)
        {
            _productService.RemoveBrand(id);
            return true;
        }

        public bool RemoveCategory(int id)
        {
            _productService.RemoveCategory(id);
            return true;
        }

        public bool RemoveProduct(int id)
        {
            _productService.RemoveProduct(id);
            return true;
        }


        #endregion
    }
}
