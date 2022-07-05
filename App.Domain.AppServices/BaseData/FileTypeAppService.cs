using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.AppServices.BaseData
{
    public class FileTypeAppService:IFileTypeAppService
    {
        private readonly IFileTypeService _fileTypeService;

        public FileTypeAppService(IFileTypeService fileTypeService)
        {
            _fileTypeService = fileTypeService;
        }
        public async Task<List<FileTypeDto>> GetAll()
        {
            var fileTypeDtos = await _fileTypeService.GetAll();
            return fileTypeDtos;
        }

        public async Task Set(string name, int fileTypeExtentionId)
        {
            //_fileTypeService.EnsureDoesNotExist(name);
            await _fileTypeService.Set(name, fileTypeExtentionId);
        }

        public FileTypeDto Get(int id)
        {
            return _fileTypeService.Get(id);
        }

        public FileTypeDto Get(string name)
        {
            return _fileTypeService.Get(name);
        }

        public void Delete(int id)
        {
            _fileTypeService.EnsureExists(id);
            _fileTypeService.Delete(id);
        }
    }
}
