using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Services.BaseData;

public class FileTypeService:IFileTypeService
{
    private readonly IFileTypeCommandRepository _fileTypeCommandRepository;
    private readonly IFileTypeQueryRepository _fileTypeQueryRepository;

    public FileTypeService(IFileTypeCommandRepository fileTypeCommandRepository, IFileTypeQueryRepository fileTypeQueryRepository)
    {
        _fileTypeCommandRepository = fileTypeCommandRepository;
        _fileTypeQueryRepository = fileTypeQueryRepository;
    }

    public async Task<List<FileTypeDto>> GetAll()
    {
        return await _fileTypeQueryRepository.GetAll();
    }
    public async Task Set(string name, int fileTypeExtentionId)
    {
        await _fileTypeCommandRepository.Add(name, fileTypeExtentionId, DateTime.Now, false);
    }

    public FileTypeDto Get(int id)
    {
        return _fileTypeQueryRepository.Get(id);
    }

    public FileTypeDto Get(string name)
    {
        return _fileTypeQueryRepository.Get(name);
    }

    public void Delete(int id)
    {
        _fileTypeCommandRepository.Delete(id);
    }

    public void EnsureDoesNotExist(string name)
    {
        var brand = _fileTypeQueryRepository.Get(name);
        if (brand != null)
            throw new Exception($"there is file with name = {name}");
    }

    public void EnsureExists(string name)
    {
        var brand = _fileTypeQueryRepository.Get(name);
        if (brand == null)
            throw new Exception($"there is no file with name = {name}");
    }

    public void EnsureExists(int id)
    {
        var brand = _fileTypeQueryRepository.Get(id);
        if (brand == null)
            throw new Exception($"there is no file with name = {id}");
    }
}