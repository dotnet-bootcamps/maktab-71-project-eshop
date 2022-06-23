namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ProductModelInputViewModel
    {
        public string Name { get; set; } = null!;
        public int ParentModelId { get; set; }
        public int BrandId { get; set; }

    }
}
