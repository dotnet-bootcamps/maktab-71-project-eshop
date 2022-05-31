using App.Infrastructures.Database.SqlServer.Entities;

public interface IColorRepository
{
    List<Color> GetAll();
    Color GetById(int id);
    void Add(Color color);
    void Update(Color color);
    void Remove(int id);

}