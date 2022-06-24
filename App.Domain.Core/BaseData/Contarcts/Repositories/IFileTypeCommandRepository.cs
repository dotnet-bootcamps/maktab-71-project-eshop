

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IFileTypeCommandRepository
    {
        Task AddFileType(string name, DateTime creationDate,int fileTypeExtentionId, bool isDeleted);
        Task UpdateFileType(int id, string name, int fileTypeExtentionId, bool isDeleted);
        Task DeleteFileType(int id);
    }
}
