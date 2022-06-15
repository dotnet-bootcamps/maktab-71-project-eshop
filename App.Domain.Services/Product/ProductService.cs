using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IProductRepository _productRepository;
        private readonly IModelRepository _modelRepository;

        public ProductService(IBrandRepository brandRepository
            , ICategoryRepository categoryRepository
            , ITagRepository tagRepository
            , IProductRepository productRepository
            , IModelRepository modelRepository)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _productRepository = productRepository;
            _modelRepository = modelRepository;
        }

        public List<Brand> GetAllBrands()
        {
            var brands = _brandRepository.GetAll();
            return brands;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return categories;
        }

        public List<Core.Product.Entities.Product> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        public List<Tag> GetAllTags()
        {
            var tags = _tagRepository.GetAll();
            return tags;
        }
        public List<Model> GetAllModels()
        {
            var models = _modelRepository.GetAll();
            return models;
        }


        public int CreateModel(Model model)
        {
            _modelRepository.Create(model);
            return model.Id;
        }

        public int CreateBrand(Brand model)
        {
            _brandRepository.Create(model);
            return model.Id;
        }

        public int CreateCategory(Category model)
        {
            _categoryRepository.Create(model);
            return model.Id;
        }

        public int CreateTag(Tag model)
        {
            _tagRepository.Create(model);
            return model.Id;
        }

        public int CreateProduct(Core.Product.Entities.Product model)
        {
            _productRepository.Create(model);
            return model.Id;
        }
    }
}
