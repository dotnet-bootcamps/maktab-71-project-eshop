using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UserManagmentController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;

        public UserManagmentController(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
           
        }
    }
}
