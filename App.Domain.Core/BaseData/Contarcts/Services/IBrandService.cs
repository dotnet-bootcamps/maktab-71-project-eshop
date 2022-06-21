using App.Domain.Core.BaseData.Dtos;
namespace App.Domain.Core.BaseData.Contarcts.Services;
public interface IBrandService
{
    Task<List<BrandDto>> GetAll();
    Task Set(string name, int displayOrder);
    BrandDto Get(int id);
    BrandDto Get(string name);
    void Update(int id, string name, int displayOrder);
    void Delete(int id);
    Task EnsureBrandDoseNotExist(string name);
    Task EnsureBrandDoseNotExist(int id);
    void EnsureBrandExists(string name);
    void EnsureBrandExists(int id);
}
