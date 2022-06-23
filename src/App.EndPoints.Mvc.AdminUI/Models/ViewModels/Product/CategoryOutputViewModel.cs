namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class CategoryOutputViewModel
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
