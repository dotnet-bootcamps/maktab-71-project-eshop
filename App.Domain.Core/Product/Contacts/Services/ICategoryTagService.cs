using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Product.Dtos;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface ICategoryTagService
    {
        Task<List<TagDto>> GetTags(int categoryId);
    }
}
