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
        Task<List<CategoryDto>> GetCategories();
        Task SetCategory(string name,int subCategoreyId, int displayOrder);
        CategoryDto GetCategory(int id);
        CategoryDto GetCategory(string name);
        void UpdateCategory(int id, string name, int subCategoreyId, int displayOrder);
        void DeleteCategory(int id);
    }
}
