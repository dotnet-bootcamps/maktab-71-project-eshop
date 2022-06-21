using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDto>> GetAll();
        Task Set(CategoryDto dto);
        Task<CategoryDto> Get(int id);
        Task<CategoryDto> Get(string name);
        Task Update(CategoryDto dto);
        void Delete(int id);
    }
}
