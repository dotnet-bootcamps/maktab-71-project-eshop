namespace App.Domain.Core.Product.Dtos
{
    public class TagDto
    {
        public int Id { get; set; }
        public int TagCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public bool HasValue { get; set; }
        public bool IsMult { get; set; }
        public string TagCategoryName { get; set; } = null!;
    }
}
