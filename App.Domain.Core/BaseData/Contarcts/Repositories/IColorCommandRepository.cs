using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IColorCommandRepository
    {
        Task AddColor(string name, DateTime creationDate, string code, bool isDeleted);
        Task UpdateColor(int id, string name, string code, bool isDeleted);
        Task DeleteColor(int id);
    }
}
