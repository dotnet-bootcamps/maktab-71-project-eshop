using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Product
{
    public interface IProductCommandRepository
    {
        Task<int> Add(ProductDto dto);
        Task addProductFiles(List<ProductFileDto> dto, int productId);
        Task Update(ProductDto dto);
        Task Delete(int id);
    }
}
