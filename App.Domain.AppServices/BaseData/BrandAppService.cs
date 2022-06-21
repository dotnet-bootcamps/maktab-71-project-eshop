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

    public void Delete(int id)
    {
        _permissionService.EnsureHasPermission(1, 7);
        _brandService.EnsureBrandExists(id);
        _brandService.Delete(id);
    }

    public BrandDto Get(int id)
    {
        return _brandService.Get(id);
    }

    public BrandDto Get(string name)
    {
        return _brandService.Get(name);
    }

    public async Task<List<BrandDto>> GetAll()
    {
        return await _brandService.GetAll();
    }

    public async Task Set(string name, int displayOrder)
    {
        await _permissionService.EnsureHasPermission(1, 5);
        await _brandService.EnsureBrandDoseNotExist(name);
        await _brandService.Set(name, displayOrder);
    }

    public void Update(int id, string name, int displayOrder)
    {
        _permissionService.EnsureHasPermission(1, 6);
        _brandService.EnsureBrandExists(id);
        _brandService.Update(id, name, displayOrder);
    }
}
