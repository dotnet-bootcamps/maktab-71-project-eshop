using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public void EnsureModelIsNotExist(string name)
        {
            var record = _modelRepository.GetByName(name);
            if (record is not null)
                throw new Exception("Model Is Already Exist");
        }
    }
}
