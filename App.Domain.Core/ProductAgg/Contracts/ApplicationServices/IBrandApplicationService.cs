using App.Domain.Core.ProductAgg.DTOs;
using App.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.ProductAgg.Contracts.ApplicationServices
{
    public interface IBrandApplicationService
    {
        void Create(CreateBrand brand);
        List<BrandViewModel> GetBrands();
        void Update(Brand command);
        void Delete(int id);
        BrandViewModel GetBrandViewModelBy(int id);
        Brand GetBrandBy(int id);

    }
}
