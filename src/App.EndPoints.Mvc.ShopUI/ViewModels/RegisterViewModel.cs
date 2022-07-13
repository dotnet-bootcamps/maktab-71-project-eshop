using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.ShopUI.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "این فیلد الزامی است")]
    [Display(Name = "نام کاربری")]
    public string UserName { get; set; }
    [Required(ErrorMessage ="این فیلد الزامی است")]
    [EmailAddress]
    [Display(Name = "ایمیل")]
    public string Email { set; get; }
    [Required(ErrorMessage ="این فیلد الزامی است")]
    [MaxLength(100,ErrorMessage = "حداکثر کارکتر {1}باشد {0} ")]
    [MinLength(5,ErrorMessage = "حداقل کارکتر {1}باشد {0} ")]
    [DataType(DataType.Password)]
    [Display(Name = "رمز عبور")]
    public string Password { get; set; }

    [Display(Name = "تکرار رمز عبور")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password),ErrorMessage = "تکرار رمز عبور باید یکسان باشد")]
    public string ConfirmPassword { set; get; }
}