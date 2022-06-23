namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class CategoryInputViewModel
    {
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
