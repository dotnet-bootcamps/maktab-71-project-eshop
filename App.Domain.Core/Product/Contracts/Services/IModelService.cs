using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IModelService
    {
        //Query
        Task<List<ModelDto>> GetAll();
        Task<ModelDto?> Get(int id);
        Task<ModelDto?> Get(string name);

        //Command
        Task<int> Create(string name, int parentModelId, int brandId);
        Task Delete(int id);
        Task Update(int id, string name, int parentModelId, int brandId, bool isDeleted);

        //Ensurness
        Task EnsureModelIsNotExist(string name);
        Task EnsureModelIsExist(string name);
        Task EnsureModelIsExist(int id);
    }
}
