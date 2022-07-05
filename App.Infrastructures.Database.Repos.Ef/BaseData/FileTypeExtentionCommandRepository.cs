using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class FileTypeExtentionCommandRepository: IFileTypeExtentionCommandRepository
    {
        private readonly AppDbContext _context;

        public FileTypeExtentionCommandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(string name, DateTime creationDate, bool isDeleted)
        {
            FileTypeExtention fileTypeExtention = new()
            {
                Name = name,
                CreationDate = creationDate,
                IsDeleted = isDeleted
            };
            await _context.FileTypeExtentions.AddAsync(fileTypeExtention);
            await _context.SaveChangesAsync();
        }
    }
}
