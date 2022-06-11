using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using App.Infrastructures.Database.SqlServer.ViewModels.Product;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _eShop;

        public ProductRepository(AppDbContext appDbContext)
        {
            _eShop = appDbContext;
        }

        public void Create(ProductSaveViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                CreationDate = DateTime.Now,
                CategoryId = model.CategoryId,
                BrandId = model.BrandId,
                Weight = model.Weight,
                IsOrginal = model.IsOrginal,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                Description = model.Description,
                Count = model.Count,
                Price = model.Price,
                IsShowPrice = model.IsShowPrice,
                OperatorId = model.OperatorId,
                ModelId = model.ModelId,
            };
            _eShop.Products.Add(product);
            _eShop.SaveChanges();
        }
        public void Update(ProductSaveViewModel model)
        {
            try
            {
                var product = _eShop.Products.SingleOrDefault(p => p.Id == model.Id);
                if (product == null) return;
                product.Name = model.Name;
                product.CategoryId = model.CategoryId;
                product.BrandId = model.BrandId;
                product.Weight = model.Weight;
                product.IsOrginal = model.IsOrginal;
                product.IsActive = model.IsActive;
                product.IsDeleted = model.IsDeleted;
                product.Description = model.Description;
                product.Count = model.Count;
                product.Price = model.Price;
                product.IsShowPrice = model.IsShowPrice;
                product.OperatorId = model.OperatorId;
                _eShop.SaveChanges();
            }
            catch (Exception dbx)
            {
                throw new Exception(dbx.Message, dbx.InnerException);
            }
            

        }

        public void Delete(int id)
        {
            try
            {
                var product = _eShop.Products.SingleOrDefault(p => p.Id == id);
                if (product == null) return;
                _eShop.Products.Remove(product);
                _eShop.SaveChanges();
            }
            catch (Exception dbx)
            {

                throw new Exception(dbx.Message, dbx.InnerException);
            }
            

        }

        public List<ProductListViewModel> GetAll()
        {
            return _eShop.Products.Select(p => new ProductListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                CreationDate = p.CreationDate,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                Weight = p.Weight,
                IsOrginal = p.IsOrginal,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                Description = p.Description,
                Count = p.Count,
                Price = p.Price,
                IsShowPrice = p.IsShowPrice,
                OperatorId = p.OperatorId,
            }).ToList();
        }
        public ProductSaveViewModel GetById(int id)
        {
            try
            {
                var product = _eShop.Products.SingleOrDefault(p => p.Id == id);
                if (product == null) return new ProductSaveViewModel();
                return new ProductSaveViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId,
                    Weight = product.Weight,
                    IsOrginal = product.IsOrginal,
                    IsActive = product.IsActive,
                    IsDeleted = product.IsDeleted,
                    Description = product.Description,
                    Count = product.Count,
                    Price = product.Price,
                    IsShowPrice = product.IsShowPrice,
                    OperatorId = product.OperatorId,
                };
            }
            catch (Exception dbx)
            {

                throw new Exception(dbx.Message, dbx.InnerException);
            }
            
        }
    }
}