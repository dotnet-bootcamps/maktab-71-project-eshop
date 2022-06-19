

using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories;
public interface IBrandQueryRepository
{
    Task<List<BrandDto>> GetAllBrands();
    BrandDto? GetBrand(int id);
    BrandDto? GetBrand(string name);
}
