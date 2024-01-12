using BulkyMvcDotNet.Data;
using BulkyMvcDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyMvcDotNet.Controllers
{
    public class CategoryController(AppDbContext db) : Controller
    {
        public IActionResult Index()
        {
            List<Category> objCagoryList = db.Categories.ToList();
            // we can also use collection expressions List<Category> objCagoryList = [.. db.Categories];
            return View(objCagoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category formObj)
        {
            //adding custom error mesg
            if(formObj.Name == formObj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("Name", "they cant have same name");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(formObj);
                db.SaveChanges();
                return RedirectToAction("index", "Category");
            }
            return View();
        }
    }
}
