using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IModelQueryRepository
    {
        Task<ModelDto?> Get(int Id);
        Task<ModelDto?> Get(string name);
        Task<List<ModelDto>> GetAll();
    }
}
