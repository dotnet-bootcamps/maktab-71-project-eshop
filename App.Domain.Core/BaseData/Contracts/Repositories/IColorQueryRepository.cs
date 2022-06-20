
using App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColorQueryRepository
    {
        Color GetById(int Id);
        List<Color> GetAll();
        int Create(Color model);
        void Update(Color model);
        bool Remove(int Id);
        Color GetExitingColor(string name, string code);
    }
}