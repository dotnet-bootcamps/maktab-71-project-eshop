using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Services;

public interface IfileTypeExtentionService
{
    Task Set(string name);
    FileTypeExtentionDto Get(int id);
    void EnsureExists(string name);

}