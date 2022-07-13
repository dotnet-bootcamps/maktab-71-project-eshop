using Microsoft.AspNetCore.Identity;

namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
