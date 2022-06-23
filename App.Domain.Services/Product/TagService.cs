using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class TagService : ITagService
    {
        private readonly ITagCommandRepository _tagCommandRepository;
        private readonly ITagQueryRepository _tagQueryRepository;

        public TagService(ITagCommandRepository tagCommandRepository
            , ITagQueryRepository tagQueryRepository)
        {
            _tagCommandRepository = tagCommandRepository;
            _tagQueryRepository = tagQueryRepository;
        }

        public async Task<int> Create(string name, int tagCategoryId, bool hasValue)
        {
            var id = await _tagCommandRepository.Add(name, tagCategoryId, hasValue, DateTime.Now, false);
            return id;
        }

        public async Task Delete(int id)
        {
            await _tagCommandRepository.Remove(id);
        }
        public async Task Update(int id, string name, int tagCategoryId, bool hasValue, bool isDeleted)
        {
            await _tagCommandRepository.Update(id, name, tagCategoryId, hasValue, isDeleted);
        }


        public async Task<TagDto?> Get(int id)
        {
            var tag=await _tagQueryRepository.Get(id);
            return tag;
        }

        public async Task<TagDto?> Get(string name)
        {
            var tag = await _tagQueryRepository.Get(name);
            return tag;
        }

        public async Task<List<TagDto>> GetAll()
        {
            var tags = await _tagQueryRepository.GetAll();
            return tags;
        }


        public async Task EnsureTagIsExist(string name)
        {
            var tag = await _tagQueryRepository.Get(name);
            if (tag == null)
                throw new Exception($"There is no Tag with Name:{ name }");
        }

        public async Task EnsureTagIsExist(int id)
        {
            var tag = await _tagQueryRepository.Get(id);
            if (tag == null)
                throw new Exception($"There is no Tag with Id:{ id }");
        }

        public async Task EnsureTagIsNotExist(string name)
        {
            var tag = await _tagQueryRepository.Get(name);
            if (tag != null)
                throw new Exception($"There is a Tag with Name:{ name }");
        }
    }
}
