using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IColorAppService
    {
        Task<List<ColorDto>> GetAll();
        Task<int> Create(string name, string code);
        Task<ColorDto> Get(int id);
        Task<ColorDto> Get(string name);
        Task Update(int id, string name, string code, bool isDeleted);
        Task Delete(int id);
    }
}
