using BulkyMvcDotNet.Data;
using BulkyMvcDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyMvcDotNet.Controllers;

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
        if (formObj.Name == formObj.DisplayOrder.ToString()) 
        {
            ModelState.AddModelError("Name", "they cant have same name");
        }
        if (ModelState.IsValid)
        {
            db.Categories.Add(formObj);
            db.SaveChanges();
            TempData["success"] = "Category created succesfully";
            return RedirectToAction("index", "Category");
        }
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0) 
        {
            return NotFound();
        }
        Category? categoryFromDb = db.Categories.Find(id); // only works on primary key
        //categoryFromDb1 = db.Categories.FirstOrDefault(u => u.Id == id); // works on any field row of table, for learning Category
        //Category categoryFromDb2 = db.Categories.Where(u => u.Id == id)..FirstOrDefault(); // works on any field row of table, for learning Category
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Category formObj)
    {
       
        if (ModelState.IsValid)
        {
            db.Categories.Update(formObj);
            db.SaveChanges();
            TempData["success"] = "Category edited succesfully";
            return RedirectToAction("index", "Category");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Category? categoryFromDb = db.Categories.Find(id); // only works on primary key
        //categoryFromDb1 = db.Categories.FirstOrDefault(u => u.Id == id); // works on any field row of table, for learning Category
        //Category categoryFromDb2 = db.Categories.Where(u => u.Id == id)..FirstOrDefault(); // works on any field row of table, for learning Category
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {

        if (ModelState.IsValid)
        {
            Category? obj = db.Categories.Find(id);
            if (obj == null) return NotFound();
            
            db.Categories.Remove(obj);
            db.SaveChanges();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("index", "Category");
        }
        return View();
    }
};
