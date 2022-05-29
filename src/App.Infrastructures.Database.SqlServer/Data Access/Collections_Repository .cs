using System;

public class Collections_Repository
{
    private AppDbContext _shopDB;

    public Collection_Repository()
    {
        _shopDB = new AppDbContext();
    }
    public void AddCollection(Collection item)
    {
        _shopDB.Collection.Add(item);
        _shopDB.SaveChanges();

    }

    public List<Collection> GetAllCollection()
    {
        return _shopDB.Collection.ToList();
    }


    public void DelteCollection(Collection item)
    {
        _shopDB.Collection.Remove(item);
        _shopDB.SaveChanges();
    }
}
