using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.ShopUI.Controllers
{
    public class TestController : Controller
    {
        public JsonResult Index()
        {
            Student student = new Student()
            {
                FirstName = "rasool",
                LastName   ="yekta",
                Id = 1
            };
            return Json(student);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
