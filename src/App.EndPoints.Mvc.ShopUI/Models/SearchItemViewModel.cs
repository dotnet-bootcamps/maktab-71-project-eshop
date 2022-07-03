namespace App.EndPoints.Mvc.ShopUI.Models
{
    public class SearchItemViewModel
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public List<string>? ImageUrls { get; set; }
        public List<string>? VideoUrls { get; set; }
        public string Name { get; set; } = null!;
        public string? Price { get; set; } = null!;
        public bool IsOrginal { get; set; }
        public int Count { get; set; }
        public List<string>? Colors { get; set; }
    }
}