using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class BrandBrifDto
    {
        public int DisplayOrder { get; set; }
        public string Name { get; set; } = null!;
    }
}
