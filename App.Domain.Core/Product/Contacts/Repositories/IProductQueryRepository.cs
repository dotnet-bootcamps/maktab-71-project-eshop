using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface IProductQueryRepository
    {
        Task<List<ProductDto>> GetAllProduct();
        ProductDto? GetProductBy(int id);
        ProductDto? GetProductBy(string name);
    }
}
