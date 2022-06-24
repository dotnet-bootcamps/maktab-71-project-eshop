using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class FileTypeService : IFileTypeService
    {
        private readonly IFileTypeQueryRepository _fileTypeQueryRepository;
        private readonly IFileTypeCommandRepository _fileTypeCommandRepository;

        public FileTypeService(IFileTypeQueryRepository fileTypeQueryRepository 
            , IFileTypeCommandRepository fileTypeCommandRepository)
        {
            _fileTypeQueryRepository = fileTypeQueryRepository;
            _fileTypeCommandRepository = fileTypeCommandRepository;
        }
        public async Task Delete(int id)
        {
            await _fileTypeCommandRepository.DeleteFileType(id);
        }

        public async Task EnsureFileTypeDoseNotExist(string name)
        {
           var file =  await _fileTypeQueryRepository.Get(name);
            if(file != null)
                throw new Exception($"There is a file with name {file}");
            
        }

        public async Task EnsureFileTypeExist(string name)
        {
            var file = await _fileTypeQueryRepository.Get(name);
            if(file == null)
            {
                throw new Exception($"There is no file with name {name}");
            }
        }

        public async Task EnsureFileTypeExist(int id)
        {
            var file = await _fileTypeQueryRepository.Get(id);
            if (file == null)
            {
                throw new Exception($"There is no file with id {id}");
            }
        }

        public async Task<FileTypeDto> Get(int id)
        {
          return await _fileTypeQueryRepository.Get(id);
        }

        public async Task<FileTypeDto> Get(string name)
        {
            return await _fileTypeQueryRepository.Get(name);
        }

        public async Task<List<FileTypeDto>> GetAll()
        {
           return await _fileTypeQueryRepository.GetAll();
        }

        public async Task Set(string name, int fileTypeExtentionId )
        {
           await _fileTypeCommandRepository.AddFileType(name, DateTime.Now, fileTypeExtentionId, false);
        }

        public async Task Update(int id, string name, int fileTypeExtentionId, bool isDeleted=false)
        {
            await _fileTypeCommandRepository.UpdateFileType(id, name, fileTypeExtentionId, isDeleted);
        }
    }
}
