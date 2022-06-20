using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Repositories
{
    public interface ITagCommandRepository 
    {
        Tag GetById(int Id);
        Tag GetByName(string name);
        List<Tag> GetAll();
        int Create(Tag model);
        void Update(Tag model);
        bool Remove(int Id);
    }
}
