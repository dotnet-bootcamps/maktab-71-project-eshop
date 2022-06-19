using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
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

        public List<BrandDto> GetAllBrands()
        {
            var brands = _brandRepository.GetAll()
                .Select(x => new BrandDto
                { Id = x.Id, Name = x.Name, IsDeleted = x.IsDeleted, CreationDate = x.CreationDate, DisplayOrder = x.DisplayOrder })
                .ToList();
            
            return brands;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll()
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate
                ,
                    DisplayOrder = x.DisplayOrder,
                    IsActive = x.IsActive,
                    ParentCagetoryId = x.ParentCagetoryId
                })
                .ToList();
            return categories;
        }

        public List<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAll()
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted
                ,
                    CreationDate = x.CreationDate,
                    Description = x.Description,
                    OperatorId = x.OperatorId,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    Count = x.Count,
                    IsActive = x.IsActive,
                    IsShowPrice = x.IsShowPrice,
                    IsOrginal = x.IsOrginal,
                    ModelId = x.ModelId,
                    Price = x.Price,
                    Weight = x.Weight
                })
                .ToList();
            return products;
        }

        public List<TagDto> GetAllTags()
        {
            var tags = _tagRepository.GetAll()
                .Select(x => new TagDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted
                ,
                    CreationDate = x.CreationDate,
                    HasValue = x.HasValue,
                    TagCategoryId = x.TagCategoryId
                })
                .ToList();
            return tags;
        }
        public List<ModelDto> GetAllModels()
        {
            var models = _modelRepository.GetAll()
                .Select(x => new ModelDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted = x.IsDeleted
                ,
                    CreationDate = x.CreationDate,
                    BrandId = x.BrandId,
                    ParentModelId = x.ParentModelId,
                })
                .ToList();
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
