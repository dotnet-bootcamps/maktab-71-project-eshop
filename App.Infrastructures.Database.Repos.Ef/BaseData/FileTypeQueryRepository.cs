using System.Security.Cryptography.X509Certificates;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.Repos.Ef.BaseData;

public class FileTypeQueryRepository: IFileTypeQueryRepository
{
    private readonly AppDbContext _context;
    public FileTypeQueryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FileTypeDto>> GetAll()
    {
        return await _context.FileTypes.AsNoTracking().Select(p => new FileTypeDto()
        {
            Id = p.Id,
            Name = p.Name,
            FileTypeExtentionId = p.FileTypeExtentionId,
            CreationDate = p.CreationDate,
            IsDeleted = p.IsDeleted,
        }).ToListAsync();
    }
    public FileTypeDto? Get(int id)
    {
        return _context.FileTypes.Where(x=>x.Id==id).Select(x=>new FileTypeDto()
        {
            Id = x.Id,
            CreationDate = x.CreationDate,
            FileTypeExtentionId = x.FileTypeExtentionId,
            IsDeleted = x.IsDeleted,
            Name = x.Name
        }).FirstOrDefault();
    }
    public FileTypeDto? Get(string name)
    {
        return _context.FileTypes.Where(x => x.Name == name).Select(x => new FileTypeDto()
        {
            Id = x.Id,
            CreationDate = x.CreationDate,
            FileTypeExtentionId = x.FileTypeExtentionId,
            IsDeleted = x.IsDeleted,
            Name = x.Name
        }).FirstOrDefault();
    }
}