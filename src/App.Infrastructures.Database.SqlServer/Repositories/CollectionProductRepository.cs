using System;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Entities;

public class CollectionProductRepository
{
    private AppDbContext _shopDB;

    public CollectionProductRepository()
    {
        _shopDB = new AppDbContext();
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
