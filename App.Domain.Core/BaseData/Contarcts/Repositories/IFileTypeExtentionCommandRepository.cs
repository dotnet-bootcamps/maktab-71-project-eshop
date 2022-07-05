namespace App.Domain.Core.BaseData.Contarcts.Repositories;

public interface IFileTypeExtentionCommandRepository
{
    Task Add(string name, DateTime creationDate, bool isDeleted);

}