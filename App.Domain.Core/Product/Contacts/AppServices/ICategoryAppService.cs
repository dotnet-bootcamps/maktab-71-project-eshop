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
        Task Set(CategorySaveDto dto);
        CategoryDto Get(int id);
        CategoryDto Get(string name);
        void Update(CategorySaveDto dto);
        void Delete(int id);
    }
}
