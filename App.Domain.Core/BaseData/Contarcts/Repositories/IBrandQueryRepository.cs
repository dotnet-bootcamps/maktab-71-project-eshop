using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories;
public interface IBrandQueryRepository
{
    Task<List<BrandDto>> GetAll();
    BrandDto? Get(int id);
    BrandDto? Get(string name);
    Task<List<BrandDto>?> GetBrands(string? name, int? id, CancellationToken cancellationToken);
}
