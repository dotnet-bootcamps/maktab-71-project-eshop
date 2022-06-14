using System;
using App.Infrastructures.Database.SqlServer.Data;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.Product.Contract.Repositories;

public class CollectionRepository :ICollectionRepository
{
    private readonly AppDbContext _shopDB;

    public CollectionRepository(AppDbContext appDbContext)
    {
        this._shopDB = appDbContext;
    }

    public Collection GetById(int id)
    {
        return _shopDB.Collections.First(p=>p.Id == id);
    }

    public List<Collection> GetAll()
    {
        return _shopDB.Collections.ToList();
    }

    public void Add(Collection item)
    {
        _shopDB.Collections.Add(item);
        _shopDB.SaveChanges();

    }

    public void Update(Collection model)
    {
        var collection = _shopDB.Collections.First(p => p.Id == model.Id);
        collection.Name = model.Name;
        collection.CreationDate = model.CreationDate;
        _shopDB.SaveChanges();
    }

    public void Remove(Collection item)
    {
        _shopDB.Collections.Remove(item);
        _shopDB.SaveChanges();
    }
}
