using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.ShopUI.Models
{
    public class AccountViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "رمز باید حداقل {2} و حداکثر {1} کارکتر باشد", MinimumLength = 2)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "باید با رمز عبور تطابق داشته باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "اطمینان رمز عبور")]
        public string PassConfirmation { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "شماره تلفن باید حداقل {2} و حداکثر {1} کارکتر باشد", MinimumLength = 3)]
        [Display(Name = "شماره تلفن")]
        public string PhoneNum { get; set; }
    }
}
