using System;
using App.Domain.Core.ProductAgg.Entities;
using App.Infrastructures.Database.SqlServer.Data;

public class CollectionProductRepository
{
    private readonly AppDbContext _shopDB;

    public CollectionProductRepository(AppDbContext appDbContext)
    {
        this._shopDB = appDbContext;
    }

    public void AddCollectionProducts(CollectionProduct item)
    {
        _shopDB.CollectionProducts.Add(item);
        _shopDB.SaveChanges();

    }

    public List<CollectionProduct> GetAllCollectionProducts()
    {
        return _shopDB.CollectionProducts.ToList();
    }


    public void DelteCollectionProducts(CollectionProduct item)
    {
        _shopDB.CollectionProducts.Remove(item);
        _shopDB.SaveChanges();
    }
}
