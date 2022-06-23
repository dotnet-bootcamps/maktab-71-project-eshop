
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Contarcts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductService(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
        }
        public async Task AddProduct(ProductDTO model)
        {
            model.CreationDate = DateTime.Now;
            model.IsDeleted = false;
            await _productCommandRepository.AddProduct(model);
        }

        public async Task DeleteProduct(ProductDTO model)
        {
            await _productCommandRepository.DeleteProduct(model);
        }

        public async Task<ProductDTO> Get(int id)
        {
            return await _productQueryRepository.Get(id);
        }

        public async Task<ProductDTO> Get(string name)
        {
            return await _productQueryRepository.Get(name);
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return await _productQueryRepository.GetAll();
        }

        public  List<BrandDto> GetAllBrands()
        {
            return  _productQueryRepository.GetAllBrands();
        }

        public List<CategoryDTO> GetAllCategories()
        {
             return _productQueryRepository.GetAllCategories();
        }

        public List<ColorDTO> GetAllColors()
        {
            return  _productQueryRepository.GetAllColors();
        }

        public List<ModelDTO> GetAllModels()
        {
            return  _productQueryRepository.GetAllModels();
        }

        public async Task UpdateProduct(ProductDTO model)
        {
            await _productCommandRepository.UpdateProduct(model);
        }

        public async Task EnsureProductDoseNotExist(string name)
        {
            var prod = _productQueryRepository.Get(name);
            if (prod != null)
            {
                throw new Exception($"Product {name} Exist in Product Table");
            }
        }

        public async Task EnsureProductExist(string name)
        {
            var prod = _productQueryRepository.Get(name);
            if (prod == null)
            {
                throw new Exception($"Product {name} Not Exist in Product Table");
            }
        }

        public async Task EnsureProductExist(int id)
        {
            var prod = _productQueryRepository.Get(id);
            if (prod == null)
            {
                throw new Exception($"Product ID {id} Not Exist in Product Table");
            }
        }


    }
}
