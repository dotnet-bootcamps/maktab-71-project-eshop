using App.Domain.Core.Product.Contacts.Repositories.Category;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryCommandRepository _commandRepository;
        private readonly ICategoryQueryRepository _queryRepository;
        public CategoryService(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository)
        {
            _queryRepository = categoryQueryRepository;
            _commandRepository = categoryCommandRepository;
        }

        public async Task Delete(int id)
        {
            await _commandRepository.Delete(id);
        }

        public async Task EnsureDoesNotExist(string name)
        {
            var record = await _queryRepository.Get(name);
            if (record != null)
            {
                throw new Exception($"Category {name} Already Exists!");
            }
        }

        public async Task EnsureExists(string name)
        {
            await _queryRepository.Get(name);
        }

        public async Task EnsureExists(int id)
        {
            await _queryRepository.Get(id);
        }

        public async Task<CategoryDto> Get(int id)
        {
            return await _queryRepository.Get(id);
        }

        public async Task<CategoryDto> Get(string name)
        {
            return await _queryRepository.Get(name);
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            return await _queryRepository.GetAll();
        }

        public async Task Set(CategoryDto dto)
        {
            await _commandRepository.Add(dto);
        }

        public async Task Update(CategoryDto dto)
        {
            await _commandRepository.Update(dto);
        }
    }
}
