using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData
{
    public class BrandOutputViewModel
    {
        [Display(Name = ("شناسه"))]
        public int Id { get; set; }
        [Display(Name = ("اولویت نمایش"))]
        public int DisplayOrder { get; set; }
        [Display(Name = ("نام برند"))]
        public string Name { get; set; } = null!;
        [Display(Name = ("تاریخ ایجاد"))]
        public DateTime CreationDate { get; set; }
        [Display(Name = ("وضعیت حذف"))]
        public bool IsDeleted { get; set; }
    }
}
