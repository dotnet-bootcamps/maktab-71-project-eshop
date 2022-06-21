using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Product.Product
{
    public class ProductQueryRepository
    {
        private readonly AppDbContext _context;

        public ModelQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ModelDto>> GetAll()
        {
            return await _context.Models.Select(p => new ModelDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                ParentModelId = p.ParentModelId,
                BrandId = p.BrandId
            }).ToListAsync();
        }

        public async Task<ModelDto> Get(int id)
        {
            var record = await _context.Models.Where(p => p.Id == id).Select(p => new ModelDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                BrandId = p.BrandId,
                ParentModelId = p.ParentModelId,
            }).SingleOrDefaultAsync();
            if (record == null)
            {
                throw new Exception($"No Model with id : {id}!");
            }
            return record;
        }

        public async Task<ModelDto> Get(string name)
        {
            var record = await _context.Models.Where(p => p.Name == name).Select(p => new ModelDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
                BrandId = p.BrandId,
                ParentModelId = p.ParentModelId,
            }).SingleOrDefaultAsync();
            if (record == null)
            {
                throw new Exception($"No Model with name : {name}!");
            }
            return record;
        }
    }
}
