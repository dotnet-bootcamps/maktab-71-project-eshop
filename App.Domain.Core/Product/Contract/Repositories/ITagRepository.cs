using TagEntities = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contract.Repositories
{
    public interface ITagRepository
    {
        List<TagEntities.Tag> GetAll();
        TagEntities.Tag GetById(int id);
        void Create(TagEntities.Tag tag);
        void Update(TagEntities.Tag tag);
        void Remove(int id);
    }
}
