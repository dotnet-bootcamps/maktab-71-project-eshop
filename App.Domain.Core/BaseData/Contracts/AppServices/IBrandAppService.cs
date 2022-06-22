
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IBrandAppService
    {
        Task<List<BrandDto>> GetAll();
        Task<int> Create(string name, int displayOrder);
        Task<BrandDto> Get(int id);
        Task<BrandDto> Get(string name);
        Task Update(int id, string name, int displayOrder);
        Task Delete(int id);
    }
}
