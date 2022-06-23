using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class ColorCommandRepository : IColorCommandRepository
    {
        private readonly AppDbContext _dbContext;

        public ColorCommandRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddColor(string code, string name, DateTime creationDate, bool isDeleted)
        {
            Color color = new Color()
            {
                Code=code,
                Name=name,
                CreationDate=creationDate,
                IsDeleted=isDeleted
            };
            //await _dbContext.AddAsync(color);
            await _dbContext.AddAsync(color);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteColor(int id)
        {
            //var color =await _dbContext.Colors.FindAsync(id);
            var color = await _dbContext.Colors.SingleOrDefaultAsync(x=>x.Id==id);
            _dbContext.Remove(color);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateColor(int id, string code, string name)
        {
            //var color =await _dbContext.Colors.FindAsync(id);
            var color =await _dbContext.Colors.SingleOrDefaultAsync(x => x.Id == id);
            color.Name = name;
            color.Code = code;
            //_dbContext.Update(color);
            await _dbContext.SaveChangesAsync();
        }
    }
}
