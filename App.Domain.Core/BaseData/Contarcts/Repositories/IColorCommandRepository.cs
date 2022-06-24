namespace App.Domain.Core.BaseData.Contarcts.Repositories;

public interface IColorCommandRepository
{
    Task AddColor(string name,string colorCode, DateTime creationDate, bool isDeleted);
    void UpdateColor(int id,string name,string colorCode);
    void DeleteColor(int id);
}