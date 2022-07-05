﻿using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories;
public interface IBrandQueryRepository
{
    Task<List<BrandDto>> GetAll();
    BrandDto? Get(int id);
    BrandDto? Get(string name);

    Task<List<BrandBriefDto>?> Search(int? brandId, string? brandName, CancellationToken cancellationToken);
}
