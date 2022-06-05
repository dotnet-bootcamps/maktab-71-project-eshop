using App.Infrastructures.Database.SqlServer.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.AdminUI.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
