using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface ICategoryQueryRepository
    {
        Task<List<CategoryDto>> GetAllCategories();
        CategoryDto? GetCategory(int id);
        CategoryDto? GetCategory(string name);
    }
}
