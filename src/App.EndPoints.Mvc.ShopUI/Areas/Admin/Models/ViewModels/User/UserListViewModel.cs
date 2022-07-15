namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.User
{
    public class UserListViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
