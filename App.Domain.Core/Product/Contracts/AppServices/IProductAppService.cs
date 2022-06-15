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


        int UpdateModel(Model model);

    }
}
