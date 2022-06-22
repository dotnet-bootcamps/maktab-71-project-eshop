using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Permission.Enums;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class BrandAppService : IBrandAppService
    {
        private readonly IBrandService _brandService;
        private readonly IPermissionService _permissionService;

        public BrandAppService(IBrandService brandService
            ,IPermissionService permissionService)
        {
            _brandService = brandService;
            _permissionService = permissionService;
        }
        public async Task<int> Create(string name, int displayOrder)
        {
            await _brandService.EnsureBrandIsNotExist(name);
            await _permissionService.HasPermission(10, (int)PermissionsEnum.ViewBrands);
            var brand = await _brandService.Create(name,displayOrder);
            return brand;
        }

        public async Task Delete(int id)
        {
            await _brandService.EnsureBrandIsExist(id);
            await _brandService.Delete(id);
        }

        public async Task<BrandDto> Get(int id)
        {
            await _brandService.EnsureBrandIsExist(id);
            var brand=await _brandService.Get(id);
            return brand;
        }

        public async Task<BrandDto> Get(string name)
        {
            await _brandService.EnsureBrandIsExist(name);
            var brand = await _brandService.Get(name);
            return brand;
        }

        public async Task<List<BrandDto>> GetAll()
        {
            var brands=await _brandService.GetAll();
            return brands;
        }

        public async Task Update(int id, string name, int displayOrder)
        {
            await _brandService.EnsureBrandIsExist(id);
            await _brandService.Update(id, name, displayOrder);
        }
    }
}
