

using App.Domain.Core.BaseData.Dtos;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IFileTypeQueryRepository
    {
        Task<List<FileTypeDto>> GetAll();
        Task<FileTypeDto> Get(int id);
        Task<FileTypeDto> Get(string name);

    }
}
