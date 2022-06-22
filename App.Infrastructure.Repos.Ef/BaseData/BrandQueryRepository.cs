using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.BaseData.Contracts.Repositories;
using System.Linq.Expressions;
using App.Domain.Core.BaseData.Dtos;

namespace App.Infrastructures.Database.SqlServer.Repositories
{

    public class BrandQueryRepository: IBrandQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public BrandQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<BrandDto>> GetAll()
        {
            var brands = await _appDbContext.Brands.Select(p => new BrandDto()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).AsNoTracking()
            .ToListAsync();
            return brands;
        }

        public async Task<BrandDto?> Get(int id)
        {

            var brand = await _appDbContext.Brands.Where(p => p.Id == id).Select(p => new BrandDto()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).SingleOrDefaultAsync();
            return brand;
        }

        public async Task<BrandDto?> Get(string name)
        {
            var brand =await _appDbContext.Brands.Where(x => x.Name.ToLower() == name.ToLower()).Select(p => new BrandDto()
            {
                Id = p.Id,
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted
            }).SingleOrDefaultAsync();
            return brand;
        }
        
        //public async Task<BrandDto?> Get(Expression<Func<BrandDto, bool>> func)
        //{
        //    var x = (IQueryable<BrandDto>)_appDbContext.Brands;
        //    var brand = _appDbContext.Brands.Where(func);
        //    var y = x.Where(func);
        //    int qq = 2;
        //    string kk = (string)qq;
        //        .Select(p => new BrandDto()
        //         {
        //             Id = p.Id,
        //             Name = p.Name,
        //             DisplayOrder = p.DisplayOrder,
        //             CreationDate = p.CreationDate,
        //             IsDeleted = p.IsDeleted
        //         }).SingleOrDefaultAsync();
        //    return brand;

        //}

    }
}


