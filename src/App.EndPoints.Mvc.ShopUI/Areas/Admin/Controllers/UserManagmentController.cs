using App.EndPoints.Mvc.ShopUI.Areas.Admin.Models.ViewModels.User;
using App.Infrastructures.Database.SqlServer.Data;
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
        private readonly AppDbContext _dbContext;

        public UserManagmentController(UserManager<IdentityUser<int>> userManager
            , RoleManager<IdentityRole<int>> roleManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index(string search = null)
        {

            //var roles = await _roleManager.Roles.ToListAsync();

            //ViewBag.Roles = roles;

            var result = await _userManager.Users.Select(x => new UserViewModel()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email
             ,
                Password = x.PasswordHash,
                Roles = string.Join(",", (_userManager.GetRolesAsync(x).Result.ToArray()))
            }).ToListAsync();
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.UserName.ToLower().Contains(search.ToLower()) || x.Email.ToLower().Contains(search.ToLower())).ToList();
            }

            return View(result);
        }




        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string username, string email, string password, string[] roles)
        {
            var hasher = new PasswordHasher<IdentityUser<int>>();
            var user = await _userManager.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
            await _userManager.ChangeEmailAsync(user, user.Email, email);
            await _userManager.SetUserNameAsync(user, username);
            //await _userManager.AddToRoleAsync(user, )
            //user.Email = email;
            //user.UserName = username;
            await _userManager.ChangePasswordAsync(user, user.PasswordHash, password);
            return View(user);
        }



        public async Task<IActionResult> Block(int id)
        {
            var result =await _userManager.Users.Where(x=>x.Id==id).SingleOrDefaultAsync();
            await _userManager.DeleteAsync(result);
            return View(result);
        }




        public async Task<IActionResult> Create()
        {

            var roles = _roleManager.Roles.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string username, string email, string password, string[] roles)
        {
            var user = new IdentityUser<int>(); /*{ Email=email,UserName=username};*/
            user.Email = email;
            user.UserName = username;
            var result = await _userManager.CreateAsync(user, password);
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    if (!string.IsNullOrEmpty(role))
                        await _userManager.AddToRoleAsync(user, role);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
