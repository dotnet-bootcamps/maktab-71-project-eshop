
namespace App.Domain.Core.Product.Dtos
{
    public class ProductInputDto
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public int ModelId { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public bool IsActive { get; set; }
        public int OperatorId { get; set; }
        public string Name { get; set; } = null!;
    }
}
