namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ProductModelOutputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ParentModelId { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
