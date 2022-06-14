using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Create(Category model)
        {
            _appDbContext.Categories.Add(model);
            _appDbContext.SaveChanges();
            return model.Id;
        }

        public void Update(Category model)
        {
            var record = _appDbContext.Categories.FirstOrDefault(p => p.Id == model.Id);
            record.Name = model.Name;
            record.DisplayOrder = model.DisplayOrder;
            record.CreationDate = model.CreationDate;
            _appDbContext.SaveChanges();
        }

        public bool Remove(int id)
        {
            var record = _appDbContext.Categories.FirstOrDefault(p => p.Id == id);
            _appDbContext.Categories.Remove(record);
            _appDbContext.SaveChanges();
            return true;
        }

        public List<Category> GetAll()
        {
            var record = _appDbContext.Categories.ToList();
            return record;
        }

        public Category GetById(int id)
        {
            var record = _appDbContext.Categories.FirstOrDefault(p => p.Id == id);
            return record;
        }
    }
}


