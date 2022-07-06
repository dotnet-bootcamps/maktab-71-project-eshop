
using App.Domain.Core.Product.Contacts.Repositories.Product;
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
    public class ProductService : IProductService
    {

        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductQueryRepository _queryRepository;
        public ProductService(IProductCommandRepository categoryCommandRepository, IProductQueryRepository categoryQueryRepository)
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
            var record = await _queryRepository.Get(name);
            if (record == null)
            {
                throw new Exception($"Category {name} Doesn't Exists!");
            }
        }

        public async Task EnsureExists(int id)
        {
            var record = await _queryRepository.Get(id);
            if (record == null)
            {
                throw new Exception($"Category {id} Doesn't Exists!");
            }
        }

        public async Task<List<ProductBriefDto>?> GetProducts(int? categoryId, string? keyword, int? minPrice, int? maxPrice, int? brandId,
            CancellationToken cancellationToken)
        {
            return await _queryRepository.Search(categoryId, keyword, minPrice, maxPrice, brandId, cancellationToken);
        }

        public async Task<ProductDto> Get(int id)
        {
            var record = await _queryRepository.Get(id);
            if (record == null)
            {
                throw new Exception($"Category {id} Doesn't Exists!");
            }
            return record;
        }

        public async Task<ProductDto> Get(string name)
        {
            var record = await _queryRepository.Get(name);
            if (record == null)
            {
                throw new Exception($"Category {name} Doesn't Exists!");
            }
            return record;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return await _queryRepository.GetAll();
        }

        public async Task Set(ProductDto dto)
        {
            await _commandRepository.Add(dto);
        }

        public async Task Update(ProductDto dto)
        {
            await _commandRepository.Update(dto);
        }

    }
}
