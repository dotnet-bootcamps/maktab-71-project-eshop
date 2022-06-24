using App.Domain.Core.Product.Contacts.Repositories;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductService(IProductQueryRepository ProductQueryRepository)
        {
            _productQueryRepository = ProductQueryRepository;
        }

        public void DeleteProduct(int id)
        {
            _productQueryRepository.DeleteProduct(id);
        }

        public List<ProductDto> GetProduct()
        {
            return _productQueryRepository.GetAllProduct();
        }

        public void SetProduct(ProductDto Pitem)
        {
            _productQueryRepository.SetProduct(Pitem);   
        }
    }
}
