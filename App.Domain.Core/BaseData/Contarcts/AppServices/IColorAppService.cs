using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.AppServices
{
    public interface IColorAppService
    {
        Task<List<ColorDto>> GetColors();
        Task SetColor(string name, string colorCode);
        ColorDto GetColor(int id);
        ColorDto GetColor(string name);
        void UpdateColor(int id, string name, string colorCode);
        void DeleteColor(int id);
    }
}
