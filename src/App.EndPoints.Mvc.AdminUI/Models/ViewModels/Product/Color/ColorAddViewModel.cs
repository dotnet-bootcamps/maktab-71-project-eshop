using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.AdminUI.ViewModels
{
    public class ColorAddViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "تکمیل فیلد کد رنگ اجباری می باشد")]
        public string Code { get; set; } = String.Empty;

        [Display(Name = "نام")]
        [Required(ErrorMessage = "تکمیل فیلد نام اجباری می باشد")]
        [StringLength(40, ErrorMessage = "حداکثر 40 کاراکتر")]
        [Remote(action: "CheckName", controller: "Color", ErrorMessage = "این رنگ قبلا ثبت شده است")]
        public string Name { get; set; } = String.Empty;
    }
}
