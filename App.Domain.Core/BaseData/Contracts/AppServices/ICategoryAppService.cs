using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDto>> GetAll();
        Task<int> Create(string name, int displayOrder, int parentCategoryId);
        Task<CategoryDto> Get(int id);
        Task<CategoryDto> Get(string name);
        Task Update(int id, string name, int displayOrder, int parentCategoryId, bool isActive, bool isDeleted);
        Task Delete(int id);
    }
}
