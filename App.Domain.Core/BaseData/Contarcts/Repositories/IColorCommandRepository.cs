using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contarcts.Repositories
{
    public interface IColorCommandRepository
    {
        
        Task AddColor(string code,string name,DateTime creationDate,bool isDeleted);
        //void UpdateColor(int id,string code,string name);
        Task UpdateColor(int id,string code,string name);
        //void DeleteColor(int id);
        Task DeleteColor(int id);
    }
}
