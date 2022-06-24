using System.Security;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Permission.Contarcts.Services;

namespace App.Domain.AppServices.BaseData;

public class ColorAppService:IColorAppService
{
    private readonly IColorService _colorService;
    private readonly IPermissionService _permissionService;

    public ColorAppService(IColorService colorService, IPermissionService permissionService)
    {
        _colorService = colorService;
        _permissionService = permissionService;
    }

    public void DeleteColor(int id)
    {
        _permissionService.HasPermission(1, 7);
        _colorService.EnsureColorExist(id);
        _colorService.DeleteColor(id);
    }

    public ColorDto GetColor(int id)
    {
        return _colorService.GetColor(id);
    }

    public ColorDto GetColor(string name)
    {
        return _colorService.GetColor(name);
    }

    public async Task<List<ColorDto>> GetColors()
    {
        return await _colorService.GetColors();
    }

    public async Task SetColor(string name,string colorCode)
    {
        _permissionService.HasPermission(1, 5);
        _colorService.EnsureColorDoseNotExist(name);
        await _colorService.SetColor(name,colorCode);
    }

    public void UpdateColor(int id, string name, string colorCode)
    {
        _permissionService.HasPermission(1, 6);
        _colorService.EnsureColorExist(id);
        _colorService.UpdateColor(id, name, colorCode);
    }
}