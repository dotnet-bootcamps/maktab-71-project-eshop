using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDto>> GetCategorys();
        Task SetCategory(bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
            bool isDeleted);
        CategoryDto GetCategory(int id);
        CategoryDto GetCategory(string name);
        void UpdateCategory(int id, bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
            bool isDeleted);
        void DeleteCategory(int id);
    }
}
