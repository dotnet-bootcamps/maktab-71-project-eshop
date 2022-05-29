namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class CategorySaveVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public int ParentCategoryId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
