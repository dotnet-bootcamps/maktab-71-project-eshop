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
        private readonly IProductService _productService;

        public ProductAppService(IProductService ProductService)
        {
            _productService = ProductService;
        }

        public List<ProductDto> Getproduct()
        {
            return _productService.GetProduct();
        }

        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }


        public void SetProduct(ProductDto Pitem)
        {
            //ensurment
            _productService.SetProduct(Pitem);
        }

        public void UpdateProduct(int id, string name)
        {
            throw new NotImplementedException();
        }

       
    }
}
