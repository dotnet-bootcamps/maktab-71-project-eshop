using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IProductAppService
    {
        List<Brand> GetAllBrands(int operatorId);
        List<Category> GetAllCategories(int operatorId);
        List<Tag> GetAllTags(int operatorId);
        List<Model> GetAllModels(int operatorId);
        List<App.Domain.Core.Product.Entities.Product> GetAllProducts(int operatorId);

        int CreateModel(Model model);
        int CreateBrand(Brand model);
        int CreateCategory(Category model);
        int CreateTag(Tag model);
        int CreateProduct(App.Domain.Core.Product.Entities.Product model);


        void UpdateModel(Model model);
        void UpdateTag(Tag model);
        void UpdateCategory(Category model);
        void UpdateBrand(Brand model);
        void UpdateProduct(App.Domain.Core.Product.Entities.Product model);

        Model GetModelById(int id);
        Tag GetTagById(int id);
        Category GetCategoryById(int id);
        Brand GetBrandById(int id);
        App.Domain.Core.Product.Entities.Product GetProductById(int id);

        bool RemoveModel(int id);
        bool RemoveTag(int id);
        bool RemoveBrand(int id);
        bool RemoveCategory(int id);
        bool RemoveProduct(int id);

    }
}
