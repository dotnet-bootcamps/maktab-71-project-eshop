using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.AppServices;

public interface IFileTypeExtentionAppService
{
    Task Set(string name);
    FileTypeExtentionDto Get(string name);
}