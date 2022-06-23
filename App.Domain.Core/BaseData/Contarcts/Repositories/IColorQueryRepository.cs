using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IColorQueryRepository
    {
        Task<List<ColorDTO>> GetAll();
        Task<ColorDTO?> Get(int id);
        Task<ColorDTO?> Get(string name);
        ColorDTO? GetFirstOrDefault(Expression<Func<ColorDTO, bool>> filter, string? includeProperties = null, bool tracked = true);
    }
}
