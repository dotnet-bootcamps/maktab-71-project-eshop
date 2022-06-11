using App.EndPoints.Mvc.AdminUI.Models;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
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

        public void Create(CategorySaveViewModel model)
        {
            var category = new Category
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                DisplayOrder = model.DisplayOrder,
                ParentCagetoryId = model.ParentCategoryId,
                CreationDate = DateTime.Now,
            };

            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
        }

        public void Update(CategorySaveViewModel model)
        {
            var record = _appDbContext.Categories.First(p => p.Id == model.Id);
            record.Name = model.Name;
            record.DisplayOrder = model.DisplayOrder;
            record.ParentCagetoryId = model.ParentCategoryId;
            record.IsActive = model.IsActive;
            record.IsDeleted = model.IsDeleted;
            _appDbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            try
            {
                var record = _appDbContext.Categories.SingleOrDefault(p => p.Id == id);
                if (record == null) return;
                _appDbContext.Categories.Remove(record);
                _appDbContext.SaveChanges();
            }
            catch (Exception dbx)
            {

                throw new Exception(dbx.Message, dbx.InnerException);
            }                                   
        }

        public List<CategoryListViewModel> GetAll()
        {
            return _appDbContext.Categories.Select(b => new CategoryListViewModel
            {
                Id = b.Id,
                Name = b.Name,
                CreationDate = b.CreationDate,
                DisplayOrder = b.DisplayOrder,
                IsActive = b.IsActive,
                IsDeleted = b.IsDeleted,
                ParentCategoryId = b.ParentCagetoryId
            }).ToList();
        }

        public CategorySaveViewModel GetById(int id)
        {
            try
            {
                var model = _appDbContext.Categories.Select(b => new CategorySaveViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    DisplayOrder = b.DisplayOrder,
                    IsActive = b.IsActive,
                    IsDeleted = b.IsDeleted,
                    ParentCategoryId = b.ParentCagetoryId
                }).SingleOrDefault(b => b.Id == id);
                if (model == null) return new CategorySaveViewModel();
                return model;
            }
            catch (Exception dbx)
            {
                throw new Exception(dbx.Message, dbx.InnerException);
            }
        }
    }
}


