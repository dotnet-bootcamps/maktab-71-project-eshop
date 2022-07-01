using App.Domain.Core.Product.Dtos.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductBriefDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public bool IsOrginal { get; set; }
        public int Count { get; set; }
        public long? Price { get; set; }
        public string Name { get; set; } = null!;
        public List<ColorDto>? Colors { get; set; } 
        public List<ProductFileDto>? Files { get; set; } 
    }
}
