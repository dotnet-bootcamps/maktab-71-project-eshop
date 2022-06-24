
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;


namespace App.Domain.Core.Product.Contacts.AppServices
{
    public interface IProductAppService
    {
        List<ProductDto> Getproduct();

        void SetProduct(ProductDto Pitem);
       
        void UpdateProduct(int id, string name);
        void DeleteProduct(int id);


    }
}
