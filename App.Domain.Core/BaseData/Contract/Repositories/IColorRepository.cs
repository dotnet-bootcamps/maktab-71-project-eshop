using colorEntities = App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.BaseData.Contract.Repositories
{
    public interface IColorRepository
    {
        void Create(colorEntities.Color color);
        void Delete(int id);
        void Edit(colorEntities.Color model);
        List<colorEntities.Color> GetAll();
        colorEntities.Color GetById(int id);
    }
}