namespace App.Domain.Core.Product.Contacts.Repositories;

public interface ICategoryCommandRepository
{
    Task AddCategory(bool isActive, int displayOrder, int parentCagetoryId, string name, DateTime creationDate,
        bool isDeleted);

    void UpdateCategory(int id, bool isActive, int displayOrder, int parentCagetoryId, string name,
        DateTime creationDate, bool isDeleted);

    void DeleteCategory(int id);
}