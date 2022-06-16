using App.Domain.Core.ProductAgg.DTOs;
using App.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAgg.Contracts.Services
{
    public interface IBrandService
    {
        void Create(CreateBrand command);
        List<BrandViewModel> GetBrands();
        BrandViewModel GetBrandViewModelBy(int id);
        Brand GetBrandBy(int id);
        void Update(Brand brand);
        void Delete(int id);
        bool Exists(string name);
        bool Exists(int id);
    }
}
