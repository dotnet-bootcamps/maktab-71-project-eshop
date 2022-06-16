using App.Domain.Core.Product.Entities;


namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IBrandRepository
    {
        Brand GetBy(int Id);
        List<Brand> GetAll();
        void Create(Brand brand);
        void Update(Brand brand);
        void Remove(int Id);
    }
}
