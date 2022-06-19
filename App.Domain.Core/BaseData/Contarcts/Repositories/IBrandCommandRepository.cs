
namespace App.Domain.Core.BaseData.Contarcts.Repositories;
public interface IBrandCommandRepository
{
    Task AddBrand(string name, int displayOrder, DateTime creationDate, bool isDeleted);
    void UpdateBrand(int id, string name, int displayOrder);
    void DeleteBrand(int id);
}
