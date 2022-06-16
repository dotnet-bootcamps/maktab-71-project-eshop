using System;
using App.Domain.Core.Product.Entities;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Contracts.Repositories;

public class CollectionRepository :ICollectionRepository
{
    private readonly AppDbContext _appDbContext;

    public CollectionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public int Create(Collection model)
    {
        _appDbContext.Collections.Add(model);
        _appDbContext.SaveChanges();
        return model.Id;

    }
    public void Update(Collection model)
    {
        var record = _appDbContext.Collections.FirstOrDefault(p => p.Id == model.Id);
        record.Name = model.Name;
        record.CreationDate = model.CreationDate;
        _appDbContext.SaveChanges();
    }
    public bool Remove(int id)
    {
        var record = _appDbContext.Collections.FirstOrDefault(p => p.Id == id);
        _appDbContext.Collections.Remove(record);
        _appDbContext.SaveChanges();
        return true;
    }
    public List<Collection> GetAll()
    {
        var record = _appDbContext.Collections.ToList();
        return record;
    }
    public Collection GetById(int id)
    {
        var record = _appDbContext.Collections.FirstOrDefault(p => p.Id == id);
        return record;
    }



    

}
