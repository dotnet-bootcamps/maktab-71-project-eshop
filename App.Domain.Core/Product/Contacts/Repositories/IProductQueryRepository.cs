using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface IProductQueryRepository
    {
       List<ProductDto> GetAllProduct();

        void DeleteProduct(int id);

        void SetProduct(ProductDto pitem);


    }

}
