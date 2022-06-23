using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.BaseData
{
    public class ColorOutputViewModel
    {
        [Display(Name = ("شناسه"))]
        public int Id { get; set; }
        [Display(Name = ("کد رنگ"))]
        public string Code { get; set; } = null!;
        [Display(Name = ("نام رنگ"))]
        public string Name { get; set; } = null!;
        [Display(Name = ("تاریخ ایجاد"))]
        public DateTime CreationDate { get; set; }
        [Display(Name = ("وضعیت حذف"))]
        public bool IsDeleted { get; set; }
    }
}
