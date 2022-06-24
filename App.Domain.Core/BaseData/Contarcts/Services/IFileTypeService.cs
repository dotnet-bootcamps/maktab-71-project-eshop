using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Services
{
    public interface IFileTypeService
    {
        Task<List<FileTypeDto>> GetAll();
        Task Set(string name, int fileTypeExtentionId);
        Task<FileTypeDto> Get(int id);
        Task<FileTypeDto> Get(string name);
        Task Update(int id, string name,int fileTypeExtentionId,bool idDeleted);
        Task Delete(int id);
        Task EnsureFileTypeDoseNotExist(string name);
        Task EnsureFileTypeExist(string name);
        Task EnsureFileTypeExist(int id);
    }
}
