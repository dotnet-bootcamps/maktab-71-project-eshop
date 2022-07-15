namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.User
{
    public class UserUpdateViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
