using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IColorService
    {
        //Query
        Task<List<ColorDto>> GetAll();
        Task<ColorDto?> Get(int id);
        Task<ColorDto?> Get(string name);

        //Command
        Task<int> Create(string name, string code);
        Task Delete(int id);
        Task Update(int id, string name, string code,bool isDeleted);

        //Ensurness
        Task EnsureColorIsNotExist(string name);
        Task EnsureColorIsExist(string name);
        Task EnsureColorIsExist(int id);
    }
}
