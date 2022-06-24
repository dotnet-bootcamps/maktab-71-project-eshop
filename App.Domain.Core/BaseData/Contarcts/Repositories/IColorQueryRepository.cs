using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IColorQueryRepository
    {
        Task<List<ColorDto>> GetAll();
        Task<ColorDto> Get(int id);
        Task<ColorDto> Get(string code);
    }
}
