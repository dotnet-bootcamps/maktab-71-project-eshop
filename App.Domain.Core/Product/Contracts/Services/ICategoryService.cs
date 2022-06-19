using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface ICategoryService
    {
        void EnsureCategoryIsNotExist(string name);
    }
}
