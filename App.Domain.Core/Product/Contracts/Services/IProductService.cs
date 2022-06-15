using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductService
    {
        List<Brand> GetAllBrands();
        List<Category> GetAllCategories();
        List<Tag> GetAllTags();
        List<Model> GetAllModels();
        List<App.Domain.Core.Product.Entities.Product> GetAllProducts();

        int CreateModel(Model model);
        int CreateBrand(Brand model);
        int CreateCategory(Category model);
        int CreateTag(Tag model);
        int CreateProduct(App.Domain.Core.Product.Entities.Product model);
    }
}
