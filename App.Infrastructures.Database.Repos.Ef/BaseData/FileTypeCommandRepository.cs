using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.Repos.Ef.BaseData
{
    public class FileTypeCommandRepository : IFileTypeCommandRepository
    {

        private readonly AppDbContext _context;

        public FileTypeCommandRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddFileType(string name, DateTime creationDate, int fileTypeExtentionId, bool isDeleted)
        {

            FileType fileType = new()
            {
                Name = name,
                FileTypeExtentionId = fileTypeExtentionId,
                CreationDate = creationDate,
                IsDeleted = isDeleted
            };
            await _context.AddAsync(fileType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFileType(int id)
        {
            var fileType = _context.FileTypes.Where(p => p.Id == id).Single();
          _context.Remove(fileType);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateFileType(int id, string name, int fileTypeExtentionId, bool isDeleted)
        {
            var fileType = _context.FileTypes.Where(p => p.Id == id).Single();
            fileType.Name = name;
            fileType.FileTypeExtentionId = fileTypeExtentionId;
            fileType.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();
        }
    }
}
