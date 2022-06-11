using App.EndPoints.Mvc.AdminUI.Models;
using App.EndPoints.Mvc.AdminUI.Models.Brand;
using App.Infrastructures.Database.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Infrastructures.Database.SqlServer.Repositories.Contracts
{
    public interface IBrandRepository
    {
        BrandSaveViewModel GetBy(int Id);
        List<BrandListViewModel> GetAll();
        void Create(BrandSaveViewModel brand);
        void Update(BrandSaveViewModel brand);
        void Remove(int Id);
    }
}
