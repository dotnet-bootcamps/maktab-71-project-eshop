using App.EndPoints.Mvc.ShopUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using App.Domain.Core.Product.Contacts.AppServices;
using App.EndPoints.Mvc.ShopUI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAppService _categoryAppService;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public HomeController(ILogger<HomeController> logger,
            ICategoryAppService categoryAppService,
            UserManager<IdentityUser<int>> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _categoryAppService.GetAll();
            ViewBag.Categorys = model.Select(x=>new CategoryVM
            {
                image = x.Image,
                name = x.Name,
                id = x.Id,
            }).ToList();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> SeedData()
        {

            //var aaa = await _userManager.FindByNameAsync("admin");
            //await _userManager.DeleteAsync(aaa);

            var adminCroleCreation = await _roleManager.CreateAsync(new IdentityRole<int>("AdminRole"));
            var customerCroleCreation = await _roleManager.CreateAsync(new IdentityRole<int>("CustomerRole"));
            var expertCroleCreation = await _roleManager.CreateAsync(new IdentityRole<int>("ExpertRole"));


            var adminResult = await _userManager.CreateAsync(new IdentityUser<int>("admin"), "1234567");
            if (adminResult.Succeeded)
            {
                var adminUser = await _userManager.FindByNameAsync("admin");
                var addAdminRole = await _userManager.AddToRoleAsync(adminUser, "AdminRole");
            }

            var customer1Result = await _userManager.CreateAsync(new IdentityUser<int>("cutomer1"), "1234567");
            if (customer1Result.Succeeded)
            {
                var customer1User = await _userManager.FindByNameAsync("cutomer1");
                var addCustomerRole = await _userManager.AddToRoleAsync(customer1User, "CustomerRole");
            }
            var expertResult = await _userManager.CreateAsync(new IdentityUser<int>("expert"), "1234567");
            if (expertResult.Succeeded)
            {
                var customer1User = await _userManager.FindByNameAsync("expert");
                var addCustomerRole = await _userManager.AddToRoleAsync(customer1User, "ExpertRole");
            }
            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}