namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ProductInputViewModel
    {
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public int ProductModelId { get; set; }
        public long Price { get; set; }
        public bool IsShowPrice { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
