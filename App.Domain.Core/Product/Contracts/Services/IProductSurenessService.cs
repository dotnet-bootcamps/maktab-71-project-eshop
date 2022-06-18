namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductSurenessService
    {
        void EnsureBrandIsNotExists(int id);
        void EnsureBrandIsNotExists(string name);
    }
}
