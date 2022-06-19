using App.Domain.Core.BaseData.Dtos;
namespace App.Domain.Core.BaseData.Contarcts.Services;
public interface IBrandService
{
    Task<List<BrandDto>> GetBrands();
    Task SetBrand(string name, int displayOrder);
    BrandDto GetBrand(int id);
    BrandDto GetBrand(string name);
    void UpdateBrand(int id, string name, int displayOrder);
    void DeleteBrand(int id);
    void EnsureBrandDoseNotExist(string name);
    void EnsureBrandExist(string name);
    void EnsureBrandExist(int id);
}
