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



        public void UpdateModel(Model model)
        {
            _modelRepository.Update(model);

        }
        public void UpdateProduct(Core.Product.Entities.Product model)
        {
            _productRepository.Update(model);
        }

        public void UpdateTag(Tag model)
        {
            _tagRepository.Update(model);
        }

        public void UpdateCategory(Category model)
        {
            _categoryRepository.Update(model);
        }

        public void UpdateBrand(Brand model)
        {
            _brandRepository.Update(model);
        }



        public Model GetModelById(int id)
        {
            var result=_modelRepository.GetById(id);
            return result;
        }

        public Tag GetTagById(int id)
        {
            var result = _tagRepository.GetById(id);
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _categoryRepository.GetById(id);
            return result;
        }

        public Brand GetBrandById(int id)
        {
            var result = _brandRepository.GetById(id);
            return result;
        }

        public Core.Product.Entities.Product GetProductById(int id)
        {
            var result = _productRepository.GetById(id);
            return result;
        }

        public bool RemoveModel(int id)
        {
            _modelRepository.Remove(id);
            return true;
        }

        public bool RemoveTag(int id)
        {
            _tagRepository.Remove(id);
            return true;
        }

        public bool RemoveBrand(int id)
        {
            _brandRepository.Remove(id);
            return true;
        }

        public bool RemoveCategory(int id)
        {
            _categoryRepository.Remove(id);
            return true;
        }

        public bool RemoveProduct(int id)
        {
            _productRepository.Remove(id);
            return true;
        }

        public void EnsureProductIsNotExist(string name, int categoryId, int brandId, int modelId)
        {
            var record = _productRepository.GetExitingProduct(name, categoryId, brandId, modelId);
            if (record is not null)
                throw new Exception("Product Is Already Exist");
        }
    }
}
