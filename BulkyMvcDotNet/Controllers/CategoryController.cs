using Microsoft.AspNetCore.Mvc;

namespace BulkyMvcDotNet.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
