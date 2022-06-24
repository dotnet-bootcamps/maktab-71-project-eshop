using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Operator.Contract.Repositories;
using App.Domain.Core.Operator.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.Operator
{
    public class OperatorQueryRepository : IOperatorQueryRepository
    {
        private readonly AppDbContext _context;

        public OperatorQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<OperatorDto>> GetAll()
        {
            return await _context.Operators.Select(p => new OperatorDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
            }).ToListAsync();
        }

        public async Task<OperatorDto>? Get(int id)
        {
            var record = await _context.Operators.Where(p => p.Id == id).Select(p => new OperatorDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
            }).SingleOrDefaultAsync();
            return record;
        }

        public async Task<OperatorDto>? Get(string name)
        {
            var record = await _context.Operators.Where(p => p.Name == name).Select(p => new OperatorDto()
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Name = p.Name,
                IsDeleted = p.IsDeleted,
            }).SingleOrDefaultAsync();
            return record;
        }
    }
}
