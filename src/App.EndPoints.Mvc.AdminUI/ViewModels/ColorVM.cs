namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class ColorVM
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
