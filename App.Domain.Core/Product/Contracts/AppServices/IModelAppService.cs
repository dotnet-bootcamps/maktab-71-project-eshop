using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.AppServices
{
    public interface IModelAppService
    {
        Task<List<ModelDto>> GetAll();
        Task<int> Create(string name, int parentModelId, int brandId);
        Task<ModelDto> Get(int id);
        Task<ModelDto> Get(string name);
        Task Update(int id, string name, int parentModelId, int brandId, bool isDeleted);
        Task Delete(int id);
    }
}
