using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contarcts.Repositories
{
    public interface IProductQueryRepository
    {
        Task<List<ProductDTO>> GetAll();
        List<CategoryDTO> GetAllCategories();
        List<BrandDto> GetAllBrands();
        List<ColorDTO> GetAllColors();
        List<ModelDTO> GetAllModels();
        Task<ProductDTO?> Get(int id);
        Task<ProductDTO?> Get(string name);
        
        //ProductDTO? GetFirstOrDefault(Expression<Func<ProductDTO, bool>> filter, string? includeProperties = null, bool tracked = true);
    }
}
