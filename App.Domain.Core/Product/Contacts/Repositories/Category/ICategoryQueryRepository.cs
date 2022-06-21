using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.Category
{
    public interface ICategoryQueryRepository
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> Get(int id);
        Task<CategoryDto> Get(string name);
    }
}
