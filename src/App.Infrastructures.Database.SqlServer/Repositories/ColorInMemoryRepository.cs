using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Repositories
{
    public class ColorInMemoryRepository : IColorRepository
    {

        private readonly AppDbContext _eshop;

        public ColorInMemoryRepository(AppDbContext appDbContext)
        {
            _eshop = appDbContext;
        }

        public void Create(Entities.Color color)
        {
            _eshop.Colors.Add(color);
            _eshop.SaveChanges();
        }
        public void Edit(Entities.Color model)
        {
            var color = _eshop.Colors.First(p => p.Id == model.Id);
            color.Name = model.Name;
            color.Code = model.Code;
            color.CreationDate = model.CreationDate;
            _eshop.SaveChanges();
        }
        public void Delete(int id)
        {
            var color = _eshop.Colors.First(p => p.Id == id);
            _eshop.Colors.Remove(color);
            _eshop.SaveChanges();
        }


        public List<Entities.Color> GetAll()
        {
            return _eshop.Colors.Include(b => b.ProductColors).ToList();
        }
        public Entities.Color GetById(int id)
        {
            return _eshop.Colors.First(p => p.Id == id);
        }
    }
}
