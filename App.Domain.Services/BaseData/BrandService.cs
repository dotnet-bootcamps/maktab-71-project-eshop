
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

    public void Delete(int id)
    {
        _brandCommandRepository.Delete(id);
    }

    public void EnsureDoesNotExist(string name)
    {
        var brand = _brandQueryRepository.Get(name);
        if (brand != null)
            throw new Exception($"there is already a brand with name = {name}");
    }

    public void EnsureExists(string name)
    {
        var brand = _brandQueryRepository.Get(name);
        if (brand == null)
            throw new Exception($"there is no brand with name = {name}");
    }

    public void EnsureExists(int id)
    {
        var brand = _brandQueryRepository.Get(id);
        if (brand == null)
            throw new Exception($"there is no brand with id = {id}");
    }

    public BrandDto Get(int id)
    {
        var brand = _brandQueryRepository.Get(id);
        if (brand == null)
            throw new Exception($"there is no brand with id = {id}");
        return brand;
    }

    public BrandDto Get(string name)
    {
        var brand = _brandQueryRepository.Get(name);
        if (brand == null)
            throw new Exception($"there is no brand with name = {name}");
        return brand;
    }


    public async Task<List<BrandDto>> GetAll()
    {
        return await _brandQueryRepository.GetAll();
    }

    public async Task Set(string name, int displayOrder)
    {
        await _brandCommandRepository.Add(name, displayOrder, DateTime.Now, false);
    }

    public void Update(int id, string name, int displayOrder, bool isDeleted)
    {
        _brandCommandRepository.Update(id, name, displayOrder, isDeleted);
    }
}
