using App.Domain.Core.ProductAgg.Contracts.Repositories;
using App.Domain.Core.ProductAgg.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Category brand)
        {
            _appDbContext.Categories.Add(brand);
            _appDbContext.SaveChanges();
        }

        public void Update(Category model)
        {
            var record = _appDbContext.Categories.First(p => p.Id == model.Id);
            record.Name = model.Name;
            record.DisplayOrder = model.DisplayOrder;
            record.CreationDate = model.CreationDate;
            _appDbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var record = _appDbContext.Categories.First(p => p.Id == id);
            _appDbContext.Categories.Remove(record);
            _appDbContext.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _appDbContext.Categories.ToList();
        }

        public Category GetBy(int id)
        {
            return _appDbContext.Categories.First(p => p.Id == id);
        }
    }
}


