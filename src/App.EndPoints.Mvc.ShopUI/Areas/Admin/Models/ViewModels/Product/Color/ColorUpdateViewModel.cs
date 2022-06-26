using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.Models.ViewModels.Product.Color
{
    public class ColorUpdateViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "تکمیل فیلد کد رنگ اجباری می باشد")]
        public string Code { get; set; } = String.Empty;

        [Display(Name = "نام")]
        [Required(ErrorMessage = "تکمیل فیلد نام اجباری می باشد")]
        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
        public string Name { get; set; } = String.Empty;
        [Display(Name = "حذف شده")]
        public bool IsDeleted { get; set; }
    }
}
