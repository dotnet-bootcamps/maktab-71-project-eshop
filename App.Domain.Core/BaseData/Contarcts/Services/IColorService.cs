using App.Domain.Core.BaseData.Dtos;
namespace App.Domain.Core.BaseData.Contarcts.Services;
public interface IColorService
{
    Task<List<ColorDto>> GetColors();
    Task SetColor(string name, string ColorCode);
    ColorDto GetColor(int id);
    ColorDto GetColor(string name);
    void UpdateColor(int id, string name,string ColorCode);
    void DeleteColor(int id);
    void EnsureColorDoseNotExist(string name);
    void EnsureColorExist(string name);
    void EnsureColorExist(int id);
}
