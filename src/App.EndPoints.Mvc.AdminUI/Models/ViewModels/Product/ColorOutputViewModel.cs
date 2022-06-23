namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ColorOutputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
