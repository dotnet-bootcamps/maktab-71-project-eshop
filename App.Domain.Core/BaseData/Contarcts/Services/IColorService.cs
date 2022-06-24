using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Services
{
    public interface IColorService
    {
        Task<List<ColorDto>> GetAll();
        Task Set(string name, string code );
        Task<ColorDto> Get(int id);
        Task<ColorDto> Get(string code);
        Task Update(int id, string name, string code, bool isDeleted);
        Task Delete(int id);
        Task EnsureFileTypeDoseNotExist(string code);
        Task EnsureFileTypeExist(string code);
        Task EnsureFileTypeExist(int id);
    }
}
