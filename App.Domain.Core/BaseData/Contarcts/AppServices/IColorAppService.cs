using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.AppServices
{
    public interface IColorAppService
    {
        Task<List<ColorDTO>> GetAll();
        Task<ColorDTO> Get(int id);
        Task<ColorDTO> Get(string name);
        Task SetColor(string code, string name);
        Task DeleteColor(int id);
        Task UpdateColor(int id, string code, string name);
        ColorDTO? GetFirstOrDefault(Expression<Func<ColorDTO, bool>> filter, string? includeProperties = null, bool tracked = true);
    }
}
