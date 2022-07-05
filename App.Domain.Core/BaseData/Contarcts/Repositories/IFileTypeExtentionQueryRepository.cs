using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories;

public interface IFileTypeExtentionQueryRepository
{
    FileTypeExtentionDto? Get(string name);
}