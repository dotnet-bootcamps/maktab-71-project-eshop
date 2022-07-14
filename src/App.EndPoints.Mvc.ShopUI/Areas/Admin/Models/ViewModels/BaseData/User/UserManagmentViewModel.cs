namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.BaseData.User
{
    public class UserManagmentViewModel
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
