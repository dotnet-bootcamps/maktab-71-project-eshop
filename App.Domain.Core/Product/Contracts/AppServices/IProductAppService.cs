using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IProductAppService
    {
        List<BrandDto> GetAllBrands(int operatorId);
        List<CategoryDto> GetAllCategories(int operatorId);
        List<TagDto> GetAllTags(int operatorId);
        List<ModelDto> GetAllModels(int operatorId);
        List<ProductDto> GetAllProducts(int operatorId);
        List<ColorDto> GetAllColors(int operatorId);

        int CreateModel(Model model);
        int CreateBrand(Brand model);
        int CreateCategory(Category model);
        int CreateTag(Tag model);
        int CreateProduct(App.Domain.Core.Product.Entities.Product model);
        int CreateColor(Color model);


        void UpdateModel(Model model);
        void UpdateTag(Tag model);
        void UpdateCategory(Category model);
        void UpdateBrand(Brand model);
        void UpdateProduct(App.Domain.Core.Product.Entities.Product model);
        void UpdateColor(Color model);

        Model GetModelById(int id);
        Tag GetTagById(int id);
        Category GetCategoryById(int id);
        Brand GetBrandById(int id);
        App.Domain.Core.Product.Entities.Product GetProductById(int id);
        Color GetColorById(int id);

        bool RemoveModel(int id);
        bool RemoveTag(int id);
        bool RemoveBrand(int id);
        bool RemoveCategory(int id);
        bool RemoveProduct(int id);
        bool RemoveColor(int id);

    }
}
