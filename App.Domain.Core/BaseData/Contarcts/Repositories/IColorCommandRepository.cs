using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IColorCommandRepository
    {
        Task AddColor(string name,string code , DateTime creationDate, bool isDeleted);
        void UpdateColor(int id, string name , string code);
        void DeleteColor(int id);
    }
}
