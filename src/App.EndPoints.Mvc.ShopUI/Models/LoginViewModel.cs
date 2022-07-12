using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.ShopUI.Models;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "ایمیل")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "رمز عبور")]
    public string Password { get; set; }

    [Display(Name = "من را به خاطر بسپار")]
    public bool RememberMe { get; set; }
}