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
        Task<List<ColorDto>> GetColors();
        Task SetColor(string name,string code);
        ColorDto GetColor(int id);
        ColorDto GetColor(string name);
        void UpdateColor(int id, string name, string code);
        void DeleteColor(int id);
        void EnsureColorDoseNotExist(string name);
        void EnsureColorExist(string name);
        void EnsureColorExist(int id);
    }
}
