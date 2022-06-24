using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class FileTypeAppService : IFileTypeAppService
    {
        private readonly IFileTypeService _fileTypeService;

        public FileTypeAppService(IFileTypeService fileTypeService )
        {
            _fileTypeService = fileTypeService;
        }
        public async Task<List<FileTypeDto>> GetAll()
        {
          var record = await _fileTypeService.GetAll();
            return record;
        }
       
        public async Task<FileTypeDto> Get(int id)
        {
          return await _fileTypeService.Get(id);
        }

        public async Task<FileTypeDto> Get(string name)
        {
            return await _fileTypeService.Get(name);
        }

        public async Task Set(string name, int fileTypeExtentionId)
        {
            await _fileTypeService.EnsureFileTypeDoseNotExist(name);
            await _fileTypeService.Set(name, fileTypeExtentionId);
        }

        public async Task Update(int id, string name, int fileTypeExtentionId, bool isDeleted)
        {
            await _fileTypeService.EnsureFileTypeExist(id);
            await _fileTypeService.Update(id, name, fileTypeExtentionId, isDeleted);
        }

        public async Task Delete(int id)
        {
           await _fileTypeService.EnsureFileTypeExist(id);
            await _fileTypeService.Delete(id);
        }
    }
}
