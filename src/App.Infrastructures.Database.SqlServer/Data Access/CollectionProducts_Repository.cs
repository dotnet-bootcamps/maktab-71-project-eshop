using System;

public class CollectionProducts_Repository
{
    private AppDbContext _shopDB;

    public CollectionProducts_Repository()
    {
        _shopDB = new AppDbContext();
    }
    public void AddCollectionProducts(CollectionProducts item)
    {
        _shopDB.CollectionProducts.Add(item);
        _shopDB.SaveChanges();

    }

    public List<CollectionProducts> GetAllCollectionProducts()
    {
        return _shopDB.CollectionProducts.ToList();
    }


    public void DelteCollectionProducts(CollectionProducts item)
    {
        _shopDB.CollectionProducts.Remove(item);
        _shopDB.SaveChanges();
    }
}
