using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
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
        private readonly IProductService _ProductService;

        public ProductAppService(IProductService productService)
        {
            _ProductService = productService;
        }

        public void DeleteProduct(int id)
        {
            _ProductService.EnsureProductExist(id);
            _ProductService.DeleteProduct(id);
        }

        public ProductDto GetProduct(int id)
            => _ProductService.GetProduct(id);

        public ProductDto GetProduct(string name)
            => _ProductService.GetProduct(name);

        public Task<List<ProductDto>> GetProducts()
             => _ProductService.GetProducts();

        public async Task SetProduct(CreateProductDto command)
        {
            _ProductService.EnsureProductDoseNotExist(command.Name);
            await _ProductService.SetProduct(command);
        }

        public void UpdateProduct(UpdateProductDto command)
        {
            _ProductService.EnsureProductExist(command.Id);
            _ProductService.UpdateProduct(command);
        }
    }
}
