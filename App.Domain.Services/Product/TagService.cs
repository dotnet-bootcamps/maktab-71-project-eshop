using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class TagService : ITagService
    {
        private readonly ITagCommandRepository _tagRepository;

        public TagService(ITagCommandRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public void EnsureTagIsNotExist(string name)
        {
            var record = _tagRepository.GetByName(name);
            if (record is not null)
                throw new Exception("Tag Is Already Exist");
        }
    }
}
