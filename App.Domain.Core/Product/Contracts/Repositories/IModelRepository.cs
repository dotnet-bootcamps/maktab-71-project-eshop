using App.Domain.Core.Product.Entities;



namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface IModelRepository
    {
        void Add(Model model);
        void Update(Model model);
        void Delete(int id);
        List<Model> GetAll();
        Model GetById(int id);
    }
}
