using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using App.EndPoints.Mvc.AdminUI.Models;
using App.Infrastructures.Database.SqlServer.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly AppDbContext _appDbContext;
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Brand> result = _appDbContext.Brands.Where(x=>x.Id==1);
            foreach (Brand brand in result)
            {
                var t=brand.Name;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}