using App.Domain.Core.BaseData.Dtos;
namespace App.Domain.Core.BaseData.Contarcts.AppServices;
public interface IBrandAppService
{
    Task<List<BrandDto>> GetBrands();
    Task SetBrand(string name, int displayOrder);
    BrandDto GetBrand(int id);
    BrandDto GetBrand(string name);
    void UpdateBrand(int id, string name, int displayOrder);
    void DeleteBrand(int id);
}
