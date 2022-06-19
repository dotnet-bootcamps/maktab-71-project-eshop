using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Permission.Contarcts.Services;

namespace App.Domain.AppServices.BaseData;
public class BrandAppService : IBrandAppService
{
    private readonly IBrandService _brandService;
    private readonly IPermissionService _permissionService;

    public BrandAppService(IBrandService brandService
        ,IPermissionService permissionService)
    {
        _brandService = brandService;
        _permissionService = permissionService;
    }

    public void DeleteBrand(int id)
    {
        _permissionService.HasPermission(1, 7);
        _brandService.EnsureBrandExist(id);
        _brandService.DeleteBrand(id);
    }

    public BrandDto GetBrand(int id)
    {
        return _brandService.GetBrand(id);
    }

    public BrandDto GetBrand(string name)
    {
        return _brandService.GetBrand(name);
    }

    public async Task<List<BrandDto>> GetBrands()
    {
        return await _brandService.GetBrands();
    }

    public async Task SetBrand(string name, int displayOrder)
    {
        _permissionService.HasPermission(1, 5);
        _brandService.EnsureBrandDoseNotExist(name);
        await _brandService.SetBrand(name, displayOrder);
    }

    public void UpdateBrand(int id, string name, int displayOrder)
    {
        _permissionService.HasPermission(1, 6);
        _brandService.EnsureBrandExist(id);
        _brandService.UpdateBrand(id, name, displayOrder);
    }
}
