using App.Domain.Core.Product.Dtos;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.Product.Contacts.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<int> Set(ProductDto dto);
        Task SetProductFiles(List<ProductFileDto> dto, int productId);
        Task<List<ProductFileDto>> UploadFiles(List<IFormFile> FormFile, int ProductId);
        Task<ProductDto> Get(int id);
        Task<ProductDto> Get(string name);
        Task Update(ProductDto dto);
        Task Delete(int id);
        Task EnsureDoesNotExist(string name);
        Task EnsureExists(string name);
        Task EnsureExists(int id);
    }
}
