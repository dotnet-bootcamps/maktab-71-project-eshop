using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos.Color;

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
        public string Description { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<ColorDto>? Colors { get; set; }
        public List<FileTypeDto>? Files { get; set; }
    }
}
