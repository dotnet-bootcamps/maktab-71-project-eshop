using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IBrandService
    {
        //Query
        Task<List<BrandDto>> GetAll();
        Task<BrandDto?> Get(int id);
        Task<BrandDto?> Get(string name);

        //Command
        Task<int> Create(string name, int displayOrder);
        Task Delete(int id);
        Task Update(int id, string name, int displayOrder);

        //Ensurness
        Task EnsureBrandIsNotExist(string name);
        Task EnsureBrandIsExist(string name);
        Task EnsureBrandIsExist(int id);
    }
}
