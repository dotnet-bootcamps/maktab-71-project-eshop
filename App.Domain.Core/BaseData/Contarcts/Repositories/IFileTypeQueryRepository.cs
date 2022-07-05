using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories;

public interface IFileTypeQueryRepository
{
    Task<List<FileTypeDto>> GetAll();
    FileTypeDto? Get(int id);
    FileTypeDto? Get(string name);
}