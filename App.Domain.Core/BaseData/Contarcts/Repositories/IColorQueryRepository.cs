

using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories;
public interface IColorQueryRepository
{
    Task<List<ColorDto>> GetAllColors();
    ColorDto? GetColor(int id);
    ColorDto? GetColor(string name);
}
