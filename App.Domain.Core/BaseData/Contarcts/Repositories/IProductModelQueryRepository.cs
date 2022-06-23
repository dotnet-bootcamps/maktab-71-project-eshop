using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IProductModelQueryRepository
    {
        Task<List<ProductModelDto>> GetAllProductModel();
        ProductModelDto? GetProductModel(int id);
        ProductModelDto? GetProductModel(string name);
    }
}
