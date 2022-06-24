using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.BaseData.Contarcts.Services;

public interface IColorService
{
    Task<List<ColorDto>> GetColors();
    Task SetColor(string name,string colorCode);
    ColorDto GetColor(int id);
    ColorDto GetColor(string name);
    void UpdateColor(int id, string name, string colorCode);
    void DeleteColor(int id);
    void EnsureColorDoseNotExist(string name);
    void EnsureColorExist(string name);
    void EnsureColorExist(int id);
}