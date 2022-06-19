
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Services.BaseData;
public class BrandService :IBrandService
{
    private readonly IBrandCommandRepository _brandCommandRepository;
    private readonly IBrandQueryRepository _brandQueryRepository;

    public BrandService(IBrandCommandRepository brandCommandRepository
        ,IBrandQueryRepository brandQueryRepository)
    {
        _brandCommandRepository = brandCommandRepository;
        _brandQueryRepository = brandQueryRepository;
    }

    public void DeleteBrand(int id)
    {
        _brandCommandRepository.DeleteBrand(id);
    }

    public void EnsureBrandDoseNotExist(string name)
    {
        var brand = _brandQueryRepository.GetBrand(name);
        if (brand != null)
            throw new Exception($"there is a brand with name = {name}");
    }

    public void EnsureBrandExist(string name)
    {
        var brand = _brandQueryRepository.GetBrand(name);
        if (brand == null)
            throw new Exception($"there is no brand with name = {name}");
    }

    public void EnsureBrandExist(int id)
    {
        var brand = _brandQueryRepository.GetBrand(id);
        if (brand == null)
            throw new Exception($"there is no brand with id = {id}");
    }

    public BrandDto GetBrand(int id)
    {
        var brand = _brandQueryRepository.GetBrand(id);
        if (brand == null)
            throw new Exception($"there is no brand with id = {id}");
        return brand;
    }

    public BrandDto GetBrand(string name)
    {
        var brand = _brandQueryRepository.GetBrand(name);
        if (brand == null)
            throw new Exception($"there is no brand with name = {name}");
        return brand;
    }

    public async Task<List<BrandDto>> GetBrands()
    {
        return await _brandQueryRepository.GetAllBrands();
    }

    public async Task SetBrand(string name, int displayOrder)
    {
        await _brandCommandRepository.AddBrand(name, displayOrder, DateTime.Now, false);
    }

    public void UpdateBrand(int id, string name, int displayOrder)
    {
        _brandCommandRepository.UpdateBrand(id, name, displayOrder);
    }
}
