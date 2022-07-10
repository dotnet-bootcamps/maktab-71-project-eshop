using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.ShopUI.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "ایمیل")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "{0} حداقل {1} کاراکتر و حداکتر {2} باشد", MinimumLength = 3)]
    [DataType(DataType.Password)]
    [Display(Name = "رمز عبور")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "تکرار رمز عبور")]
    [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار رمز هبور باید یکسان باشند")]
    public string ConfirmPassword { get; set; }
}