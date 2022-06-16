using App.Domain.Core.Product.Entities;
namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ICollectionProductRepository
    {
        void AddCollectionProducts(CollectionProduct item);
        void DelteCollectionProducts(CollectionProduct item);
        List<CollectionProduct> GetAllCollectionProducts();
    }
}