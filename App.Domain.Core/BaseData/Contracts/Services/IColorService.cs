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
        List<Color> GetAllColors();
        Color GetColorById(int id);
        int CreateColor(Color color);
        bool RemoveColor(int id);
        void UpdateColor(Color color);
        void EnsureColorIsNotExist(string name,string code);
    }
}
