using App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.BaseData.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.Mvc.ShopUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UserManagmentController : Controller
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public UserManagmentController(UserManager<IdentityUser<int>> userManager
            , RoleManager<IdentityRole<int>> roleManager
            ,SignInManager<IdentityUser<int>> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string? name)
        {
            var user = await _userManager.Users.ToListAsync();
            var result = user.Select(u => new UserManagmentViewModel()
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                Password = u.PasswordHash,
                Roles = (_userManager.GetRolesAsync(u).Result).ToList()
            }).ToList();

            if (name != null)
            {
             var results = result.Where(x => x.UserName.ToLower().Contains(name) || x.Email.ToLower().Contains(name))
                    .ToList();
                return View(results);
            }
            
            return View(result);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(UserManagmentViewModel model)
        {
            var user = _userManager.Users.ToList();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,string username)
        {
            var user = _userManager.Users.ToList();
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.Roles = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserManagmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser<int>
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    foreach (var role in model.Roles)
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,item.Description);
                    }
                }
               
            }

            return View(model);

        }
    }
}
