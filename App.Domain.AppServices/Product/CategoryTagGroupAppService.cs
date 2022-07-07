using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class CategoryTagGroupAppService : ICategoryTagGroupAppService
    {

        private readonly ICategoryTagGroupService _service;

        public CategoryTagGroupAppService(ICategoryTagGroupService service)
        {
            _service = service;
        }

        public async Task<List<TagDto>> getTags(int categoryId)
        {
            return await _service.getTags(categoryId);
        }
    }
}
