using App.Domain.Core.Product.Contacts.Repositories.TagCategory;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class CategoryTagGroupService : ICategoryTagGroupService
    {
        private readonly ICategoryTagGroupRepository _repository;

        public CategoryTagGroupService(ICategoryTagGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TagDto>> getTags(int categoryId)
        {
            return await _repository.getTags(categoryId);
        }
    }
}
