using App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.User;
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

        public UserManagmentController(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var model = users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
            }).ToList();
            model.ForEach(m =>
                {
                    var user = users.FirstOrDefault(u => u.UserName == m.UserName);
                    m.Roles = _userManager.GetRolesAsync(user).Result.ToList();
                });
            //Task.Factory.StartNew(new Action(a));
            //void a()
            //{
            //    model.ForEach(async m =>
            //    {
            //        var user = users.FirstOrDefault(u => u.UserName == m.UserName);
            //        var Roles = await _userManager.GetRolesAsync(user);
            //    });
            //}
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser<int>
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            var model = new UserUpdateViewModel
            {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
            };
            model.Roles = _userManager.GetRolesAsync(user).Result.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id.ToString());
                user.Id = model.Id;
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                    result = await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                if (result.Succeeded)
                    result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    result = await _userManager.AddToRolesAsync(user, model.Roles);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
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


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
