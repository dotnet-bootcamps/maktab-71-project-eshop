using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IBrandQueryRepository
    {
        Task<BrandDto?> Get(int Id);
        Task<BrandDto?> Get(string name);
        Task<List<BrandDto>> GetAll();
    }
}
