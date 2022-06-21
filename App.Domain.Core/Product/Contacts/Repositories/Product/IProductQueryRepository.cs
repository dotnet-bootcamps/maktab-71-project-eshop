using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Color
{
    public interface IProductQueryRepository
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name);
    }
}
