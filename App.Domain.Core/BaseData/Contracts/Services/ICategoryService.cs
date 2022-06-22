using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface ICategoryService
    {
        //Query
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto?> Get(int id);
        Task<CategoryDto?> Get(string name);

        //Command
        Task<int> Create(string name, int displayOrder,int parentCategoryId);
        Task Delete(int id);
        Task Update(int id, string name, int displayOrder, int parentCategoryId,bool isActive,bool isDeleted);

        //Ensurness
        Task EnsureCategoryIsNotExist(string name);
        Task EnsureCategoryIsExist(string name);
        Task EnsureCategoryIsExist(int id);
    }
}
