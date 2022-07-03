using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IProductAppService
    {
        Task<List<ProductDto>> GetAll();
        Task<int> Set(ProductDto productDto, List<IFormFile> FormFile);
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name);
        Task Update(ProductDto dto);
        Task Delete(int id);
    }
}
