using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class BrandInputViewModel
    {
        [Display(Name = "نام")]
        public string Name { get; set; } = null!;

        [Display(Name = "ترتیب نمایش")]
        public int DisplayOrder { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
