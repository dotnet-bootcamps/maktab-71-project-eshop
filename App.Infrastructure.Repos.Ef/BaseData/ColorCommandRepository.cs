using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repos.Ef.BaseData
{
    public class ColorCommandRepository : IColorCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public ColorCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(string name, string code, DateTime creationDate, bool isDeleted)
        {
            var color =new Color()
            {
                Name = name,
                Code = code,
                CreationDate = creationDate,
                IsDeleted = isDeleted
            };
            _appDbContext.Colors.Add(color);
            await _appDbContext.SaveChangesAsync();
            return color.Id;
        }

        public async Task Remove(int Id)
        {
            var color =await _appDbContext.Colors.SingleAsync(color => color.Id == Id);
            _appDbContext.Colors.Remove(color);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, string name, string code, bool isDeleted)
        {
            var color = await _appDbContext.Colors.SingleAsync(color => color.Id == id);
            color.Name = name;
            color.Code = code;
            color.IsDeleted = isDeleted;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
