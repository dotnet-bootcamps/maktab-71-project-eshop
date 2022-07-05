﻿using App.Domain.Core.BaseData.Dtos;
namespace App.Domain.Core.BaseData.Contarcts.Services;
public interface IBrandService
{
    Task<List<BrandDto>> GetAll();
    Task Set(string name, int displayOrder);
    BrandDto Get(int id);
    BrandDto Get(string name);
    void Update(int id, string name, int displayOrder, bool isDeleted);
    void Delete(int id);
    void EnsureDoesNotExist(string name);
    void EnsureExists(string name);
    void EnsureExists(int id);

    Task<List<BrandBriefDto>?> GetBrands(int? brandId, string? brandName, CancellationToken cancellationToken);
}
