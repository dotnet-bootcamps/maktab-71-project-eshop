using App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.BaseData;
using App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.BaseData.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        public UserManagementController(UserManager<IdentityUser<int>> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            SignInManager<IdentityUser<int>> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string? SearchStrin)
        {
            var users = await _userManager.Users.ToListAsync();
            var model = users.Select(x => new UserOutputVM
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                Roles = (_userManager.GetRolesAsync(x).Result).ToList()
            }).ToList();
            if (!string.IsNullOrEmpty(SearchStrin))
            {
                model = model.Where(s => s.UserName.ToLower()!.Contains(SearchStrin.ToLower())).ToList();
            }


            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserInputVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser<int>
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    var rols = _roleManager.Roles.Where(x => model.RolsInts.Contains(x.Id)).ToList();
                    foreach (var rol in rols)
                    {
                        await _userManager.AddToRoleAsync(user, rol.Name);
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect("~/");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
