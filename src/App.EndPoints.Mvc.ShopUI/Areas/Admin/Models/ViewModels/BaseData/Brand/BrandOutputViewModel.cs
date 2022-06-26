using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product
{
    public class BrandOutputViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int DisplayOrder { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; } = null!;

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
