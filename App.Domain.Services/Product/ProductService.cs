
using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
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

        public async Task<int> Set(ProductDto dto) 
            => await _commandRepository.Add(dto);

        public async Task SetProductFiles(List<ProductFileDto> dto,int productId)
           => await _commandRepository.addProductFiles(dto, productId);

        public async Task<List<ProductFileDto>> UploadFiles(List<IFormFile> FormFile, int ProductId)
        {
            var files = new List<string>();
            foreach (var formFile in FormFile)
            {
                if (formFile.Length > 0)
                {
                    var filename = Path.Combine("Upload", Guid.NewGuid().ToString() +
                        ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"'));
                    files.Add(filename);
                    try
                    {
                        using (var stream = System.IO.File.Create(filename))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                    catch
                    {
                        throw new Exception("Upload files operation failed");
                    }
                }
            }
            var productFiles = new List<ProductFileDto>();
            foreach (var file in files)
            {
                ProductFileDto productfile = new ProductFileDto
                {
                    Name = file,
                    FileType = System.IO.Path.GetExtension(file).ToLower(),
                    ProductId = ProductId

                };
                productFiles.Add(productfile);
            }
            return productFiles;
        }
        public async Task Update(ProductDto dto)
        {
            await _commandRepository.Update(dto);
        }

    }
}
