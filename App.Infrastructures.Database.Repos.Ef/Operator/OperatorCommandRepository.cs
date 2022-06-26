using App.Domain.Core.Operator.Contract.Repositories;
using App.Domain.Core.Operator.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.Operator
{
    public class OperatorCommandRepository : IOperatorCommandRepository
    {
        private readonly AppDbContext _context;

        public OperatorCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(OperatorDto dto)
        {
            App.Domain.Core.Operator.Entities.Operator o = new()
            {
                Name = dto.Name,
                CreationDate = dto.CreationDate,
                IsDeleted = dto.IsDeleted,
            };
            await _context.Operators.AddAsync(o);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var category = await _context.Operators.Where(p => p.Id == id).SingleAsync();

            _context.Remove(category!);
            await _context.SaveChangesAsync();
        }

        public async Task Update(OperatorDto dto)
        {
            var op = await _context.Operators.Where(p => p.Id == dto.Id).SingleAsync();
            op.Name = dto.Name;
            op.CreationDate = dto.CreationDate;
            op.IsDeleted = dto.IsDeleted;
            await _context.SaveChangesAsync();
        }
    }
}
