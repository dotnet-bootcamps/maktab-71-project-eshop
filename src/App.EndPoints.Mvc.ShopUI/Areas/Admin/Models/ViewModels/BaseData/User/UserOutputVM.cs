namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.BaseData.User
{
    public class UserOutputVM
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public List<string?> Roles { set; get; }
    }
}
