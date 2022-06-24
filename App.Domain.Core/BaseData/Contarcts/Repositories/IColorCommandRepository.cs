
namespace App.Domain.Core.BaseData.Contarcts.Repositories;
public interface IColorCommandRepository
{
    Task AddColor(string name, string ColorCode, DateTime creationDate, bool isDeleted);
    void UpdateColor(int id, string name, string ColorCode);
    void DeleteColor(int id);
}
