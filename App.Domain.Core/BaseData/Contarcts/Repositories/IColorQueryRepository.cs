using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories;

public interface IColorQueryRepository
{
    Task<List<ColorDto>> GetAllColor();
    ColorDto? GetColorBy(int id);
    ColorDto? GetColorBy(string name);
}