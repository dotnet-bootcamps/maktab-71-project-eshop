using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface ICategoryQueryRepository
    {
        Task<CategoryDto?> Get(int Id);
        Task<CategoryDto?> Get(string name);
        Task<List<CategoryDto>> GetAll();
    }
}
