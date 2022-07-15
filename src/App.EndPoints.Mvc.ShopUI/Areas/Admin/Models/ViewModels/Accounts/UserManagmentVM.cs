using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.Accounts
{
    public class UserManagmentVM
    {
        [Display(Name = "شماره کاربری")]
        public int Id { get; init; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن")]
        public string? PhoneNumber { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();
    }
}