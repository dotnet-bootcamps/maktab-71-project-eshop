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
        Task<List<CategoryDto>> GetCategories();
        Task SetCategory(string name, int displayOrder ,int parentCategoryId);
        CategoryDto GetCategory(int id);
        CategoryDto GetCategory(string name);
        void UpdateCategory(int id, string name, int displayOrder, int parentCategoryId);
        void DeleteCategory(int id);
        void EnsureCategoryDoseNotExist(string name);
        void EnsureCategoryExist(string name);
        void EnsureCategoryExist(int id);
    }
}
