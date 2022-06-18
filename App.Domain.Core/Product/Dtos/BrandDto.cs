
namespace App.Domain.Core.Product.Dtos
{
    public partial class BrandDto
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
