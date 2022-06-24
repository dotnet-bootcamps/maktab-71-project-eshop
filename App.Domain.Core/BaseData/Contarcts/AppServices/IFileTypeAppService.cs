using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.AppServices
{
    public interface IFileTypeAppService
    {
        Task<List<FileTypeDto>> GetAll();
        Task<FileTypeDto> Get(int id);
        Task<FileTypeDto> Get(string name);
        Task Set(string name, int fileTypeExtentionId);
        Task Update ( int id , string name , int fileTypeExtentionId, bool isDeleted);
        Task Delete (int id );
    }
}
