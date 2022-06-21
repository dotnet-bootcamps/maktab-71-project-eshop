using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Repositories
{
    public interface IProductCommandRepository
    {
        Task Add(ProductInputDto product, DateTime creationDate, bool isDeleted);
        Task Update(int id, ProductInputDto product, DateTime creationDate, bool isDeleted);
        Task Delete(int id);
    }
}
