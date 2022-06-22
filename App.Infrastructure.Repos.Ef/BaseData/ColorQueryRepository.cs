using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ColorQueryRepository : IColorQueryRepository
    {

        private readonly AppDbContext _appDbContext;

        public ColorQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ColorDto?> Get(int id)
        {
            var color = await _appDbContext.Colors.Where(x => x.Id == id).Select(x => new ColorDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                IsDeleted = x.IsDeleted,
                Code = x.Code
            }).SingleAsync();
            return color;
        }

        public async Task<ColorDto?> Get(string name)
        {
            var color = await _appDbContext.Colors.Where(x => x.Name.ToLower() == name.ToLower()).Select(x => new ColorDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                IsDeleted = x.IsDeleted,
                Code = x.Code
            }).SingleAsync();
            return color;
        }

        public async Task<List<ColorDto>> GetAll()
        {
            var colors = await _appDbContext.Colors.Select(x => new ColorDto()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate,
                Code= x.Code,
                IsDeleted = x.IsDeleted
            }).ToListAsync();
            return colors;
        }
    }
}
