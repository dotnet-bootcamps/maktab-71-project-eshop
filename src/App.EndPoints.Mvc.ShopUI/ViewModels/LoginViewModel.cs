using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.ShopUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
