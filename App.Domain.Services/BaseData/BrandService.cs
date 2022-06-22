using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class BrandService : IBrandService
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;

        public BrandService(IBrandCommandRepository brandCommandRepository
            , IBrandQueryRepository brandQueryRepository
            )
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;
        }
        //Command :

        public async Task<int> Create(string name, int displayOrder)
        {
            var id = await _brandCommandRepository.Add(name, displayOrder, DateTime.Now, false);
            return id;
        }
        public async Task Delete(int id)
        {
            await _brandCommandRepository.Remove(id);
        }

        public async Task Update(int id, string name, int displayOrder)
        {
            await _brandCommandRepository.Update(id,name,displayOrder);
        }

        //Query :

        public async Task<List<BrandDto>> GetAll()
        {
            var brands= await _brandQueryRepository.GetAll();
            return brands;
        }

        public async Task<BrandDto?> Get(int id)
        {
            var brand = await _brandQueryRepository.Get(id);
            return brand;
        }

        public async Task<BrandDto?> Get(string name)
        {
            var brand = await _brandQueryRepository.Get(name);
            return brand;
        }
        
        //Ensurness :

        public async Task EnsureBrandIsExist(string name)
        {
            var brand = await _brandQueryRepository.Get(name);
            if (brand == null)
                throw new Exception($"There Is No Brand With Name : {name}");
        }

        public async Task EnsureBrandIsExist(int id)
        {
            var brand = await _brandQueryRepository.Get(id);
            if (brand == null)
                throw new Exception($"There Is No Brand With Id : {id}");
        }

        public async Task EnsureBrandIsNotExist(string name)
        {
            var brand = await _brandQueryRepository.Get(name);
            if (brand != null)
                throw new Exception($"There Is A Brand With Name : {name}");
        } 
    }
}
