namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class ColorOutputViewModel
    {
        public int Id { set; get; }
        public string ColorCode { set; get; }
        public string Name { set; get; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
