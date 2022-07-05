using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Services;

public interface IFileTypeService
{
    Task<List<FileTypeDto>> GetAll();
    Task Set(string name, int fileTypeExtentionId);
    FileTypeDto Get(int id);
    FileTypeDto Get(string name);
    void Delete(int id);
    void EnsureDoesNotExist(string name);
    void EnsureExists(string name);
    void EnsureExists(int id);
}