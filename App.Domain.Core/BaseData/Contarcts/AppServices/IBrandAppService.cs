using App.Domain.Core.BaseData.Dtos;
namespace App.Domain.Core.BaseData.Contarcts.AppServices;
public interface IBrandAppService
{
    Task<List<BrandDto>> GetAll();
    Task Set(string name, int displayOrder);
    BrandDto Get(int id);
    BrandDto Get(string name);
    Task<List<BrandDto>?> GetBrands(string? name, int? id, CancellationToken cancellationToken);
    void Update(int id, string name, int displayOrder, bool isDeleted);
    void Delete(int id);
}
