using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Permission.Contarcts.Services;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }
        public async Task AddProduct(ProductDTO model)
        {
            await _productService.EnsureProductDoseNotExist(model.Name);
            await _productService.AddProduct(model);
        }

        public async Task DeleteProduct(ProductDTO model)
        {
            await _productService.EnsureProductExist(model.Id);
            await _productService.DeleteProduct(model);
        }

        public async Task<ProductDTO> Get(int id)
        {
            return await _productService.Get(id);
        }

        public async Task<ProductDTO> Get(string name)
        {
            return await _productService.Get(name);
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return await _productService.GetAll();
        }

        public List<BrandDto> GetAllBrands()
        {
            return _productService.GetAllBrands();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return  _productService.GetAllCategories();
        }

        public List<ColorDTO> GetAllColors()
        {
            return _productService.GetAllColors();
        }

        public List<ModelDTO> GetAllModels()
        {
            return _productService.GetAllModels();
        }

        public async Task UpdateProduct(ProductDTO model)
        {
            await _productService.EnsureProductExist(model.Id);
            await _productService.UpdateProduct(model);
        }
    }
}
