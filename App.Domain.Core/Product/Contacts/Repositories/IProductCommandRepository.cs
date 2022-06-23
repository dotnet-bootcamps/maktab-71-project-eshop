using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contarcts.Repositories
{
    public interface IProductCommandRepository
    {
        
        Task AddProduct(ProductDTO model);
        
        Task UpdateProduct(ProductDTO model);
        
        Task DeleteProduct(ProductDTO model);
    }
}
