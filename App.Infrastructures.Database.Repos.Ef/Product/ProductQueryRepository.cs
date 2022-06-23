using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Contarcts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductQueryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProductDTO>> GetAll()
        {
           return await _dbContext.Products
                .Include(x=>x.Category)
                .Include(x=>x.Brand)
                .Include(x=>x.Model)
                .AsNoTracking()
                .Select(a=>new ProductDTO()
            {
                Id=a.Id,
                Name=a.Name,
                CreationDate=a.CreationDate,
                IsDeleted=a.IsDeleted,
                Count=a.Count,
                Description=a.Description,
                Price=a.Price,
                Weight=a.Weight,
                IsActive=a.IsActive,
                IsOrginal=a.IsOrginal,
                IsShowPrice=a.IsShowPrice,
                CategoryId=a.CategoryId,
                BrandId=a.BrandId,
                ModelId=a.ModelId,
                OperatorId=a.OperatorId,
                CategoryName=a.Category.Name,
                BrandName=a.Brand.Name,
                ModelName=a.Model.Name
            }).ToListAsync();   
        }
        public async Task<List<ProductDTO>> GetAllProduct()
        {
            return await _dbContext.Products
                 .AsNoTracking()
                 .Select(a => new ProductDTO()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     CreationDate = a.CreationDate,
                     IsDeleted = a.IsDeleted,
                     Count = a.Count,
                     Description = a.Description,
                     Price = a.Price,
                     Weight = a.Weight,
                     IsActive = a.IsActive,
                     IsOrginal = a.IsOrginal,
                     IsShowPrice = a.IsShowPrice,
                     CategoryId = a.CategoryId,
                     BrandId = a.BrandId,
                     ModelId = a.ModelId,
                     OperatorId = a.OperatorId,
                 }).ToListAsync();
        }
        public async Task<ProductDTO?> Get(int id)
        {
            return await _dbContext.Products.AsNoTracking().Where(b => b.Id == id).Select(a=>new ProductDTO()
            {
                Id = a.Id,
                Name = a.Name,
                CreationDate = a.CreationDate,
                IsDeleted = a.IsDeleted,
                Count = a.Count,
                Description = a.Description,
                Price = a.Price,
                Weight = a.Weight,
                IsActive = a.IsActive,
                IsOrginal = a.IsOrginal,
                IsShowPrice = a.IsShowPrice,
                CategoryId = a.CategoryId,
                BrandId = a.BrandId,
                ModelId = a.ModelId,
                OperatorId = a.OperatorId
            }).FirstOrDefaultAsync();
            
            
        }

        public async Task<ProductDTO?> Get(string name)
        {
            return await _dbContext.Products.AsNoTracking().Where(b => b.Name == name).Select(a => new ProductDTO()
            {
                Id = a.Id,
                Name = a.Name,
                CreationDate = a.CreationDate,
                IsDeleted = a.IsDeleted,
                Count = a.Count,
                Description = a.Description,
                Price = a.Price,
                Weight = a.Weight,
                IsActive = a.IsActive,
                IsOrginal = a.IsOrginal,
                IsShowPrice = a.IsShowPrice,
                CategoryId = a.CategoryId,
                BrandId = a.BrandId,
                ModelId = a.ModelId,
                OperatorId = a.OperatorId
            }).SingleOrDefaultAsync();
            
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return  _dbContext.Categories.AsNoTracking().Select(x=>new CategoryDTO()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public  List<BrandDto> GetAllBrands()
        {
            return _dbContext.Brands.AsNoTracking().Select(x=>new BrandDto()
            {
                Id=x.Id,
                Name=x.Name,
            }).ToList();
        }

        public List<ColorDTO> GetAllColors()
        {
            return  _dbContext.Colors.AsNoTracking().Select(x=>new ColorDTO()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public List<ModelDTO> GetAllModels()
        {
            return _dbContext.Models.AsNoTracking().Select(x => new ModelDTO()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        /*public ProductDTO? GetFirstOrDefault(Expression<Func<ProductDTO, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<ProductDTO> query;
            if (tracked)
            {
                //query = (IQueryable<ColorDTO>)_dbContext.Colors;
                query = _dbContext.Colors.Select(b => new ColorDTO()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Code = b.Code,
                    CreationDate = b.CreationDate,
                    IsDeleted = b.IsDeleted
                });
            }
            else
            {
                query = _dbContext.Colors.AsNoTracking().Select(b => new ColorDTO()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Code = b.Code,
                    CreationDate = b.CreationDate,
                    IsDeleted = b.IsDeleted
                }); ;
            }
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
*/

    }
}
