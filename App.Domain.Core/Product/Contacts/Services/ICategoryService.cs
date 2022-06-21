using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();
        Task Set(CategoryDto dto);
        Task<CategoryDto> Get(int id);
        Task<CategoryDto> Get(string name);
        Task Update(CategoryDto dto);
        Task Delete(int id);
        Task EnsureDoesNotExist(string name);
        Task EnsureExists(string name);
        Task EnsureExists(int id);
    }
}
