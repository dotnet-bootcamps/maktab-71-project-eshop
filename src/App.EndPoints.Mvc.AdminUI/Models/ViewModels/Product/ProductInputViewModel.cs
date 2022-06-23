namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ProductInputViewModel
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public decimal Weight { get; set; }
        public bool IsOrginal { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public long Price { get; set; }
        public string Name { get; set; } = null!;
    }
}
