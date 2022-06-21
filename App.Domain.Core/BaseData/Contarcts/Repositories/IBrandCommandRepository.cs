
namespace App.Domain.Core.BaseData.Contarcts.Repositories;
public interface IBrandCommandRepository
{
    Task Add(string name, int displayOrder, DateTime creationDate, bool isDeleted);
    void Update(int id, string name, int displayOrder);
    void Delete(int id);
}
