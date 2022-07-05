using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructures.Database.SqlServer.Data;

namespace App.Infrastructures.Database.Repos.Ef.BaseData;

public class FileTypeCommandRepository: IFileTypeCommandRepository
{
    private readonly AppDbContext _context;

    public FileTypeCommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(string name, int fileTypeExtentionId, DateTime creationDate, bool isDeleted)
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

    public async Task Delete(int id)
    {
        var fileType = _context.FileTypes.SingleOrDefault(x=>x.Id==id);
         _context.Remove(fileType);
         await _context.SaveChangesAsync();
    }
}