using App.Infrastructures.Database.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface ITagRepository
    {
        void Create(Tag tag);
        void Remove(int id);
        void Update(Tag tag);
        List<Tag> GetAll();
        
    }
}
