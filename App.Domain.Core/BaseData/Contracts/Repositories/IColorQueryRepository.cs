using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColorQueryRepository
    {
        Task<ColorDto?> Get(int Id);
        Task<ColorDto?> Get(string name);
        Task<List<ColorDto>> GetAll();
    }
}