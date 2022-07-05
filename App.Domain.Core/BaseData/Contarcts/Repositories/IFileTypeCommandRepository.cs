namespace App.Domain.Core.BaseData.Contarcts.Repositories;

public interface IFileTypeCommandRepository
{
    Task Add(string name, int fileTypeExtentionId, DateTime creationDate, bool isDeleted);
    Task Delete(int id);
}