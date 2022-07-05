using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.AppServices;

public interface IFileTypeAppService
{
    Task<List<FileTypeDto>> GetAll();
    Task Set(string name, int fileTypeExtentionId);
    FileTypeDto Get(int id);
    FileTypeDto Get(string name);
    void Delete(int id);
}