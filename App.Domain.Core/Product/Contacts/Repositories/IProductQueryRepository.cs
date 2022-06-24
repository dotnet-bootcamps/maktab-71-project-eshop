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
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name);
    }
}
