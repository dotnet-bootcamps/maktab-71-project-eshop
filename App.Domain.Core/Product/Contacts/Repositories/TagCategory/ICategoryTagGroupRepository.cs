using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contacts.Repositories.TagCategory
{
    public interface ICategoryTagGroupRepository
    {
        Task<List<TagDto>> getTags(int categoryId);

    }
}
