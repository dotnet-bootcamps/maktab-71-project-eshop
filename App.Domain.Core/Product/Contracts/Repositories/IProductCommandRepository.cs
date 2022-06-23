using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IProductCommandRepository
    {
        Task<int> Add(ProductDto product);
        Task Update(ProductDto product);
        Task Remove(int Id);


    }
}
