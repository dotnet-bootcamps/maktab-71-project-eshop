using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IProductQueryRepository
    {
        Task<ProductDto?> Get(int Id);
        Task<ProductDto?> Get(string name,int brandId,int categoryId,int modelId);
        Task<List<ProductDto>> GetAll();
    }
}
