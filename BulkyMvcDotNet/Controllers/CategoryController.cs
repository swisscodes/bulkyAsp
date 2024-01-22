using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyMvcDotNet.Controllers;

public class CategoryController(IUnitOfWork unitOfWork) : Controller
{
    public IActionResult Index()
    {
        List<Category> objCategoryList = unitOfWork.Category.GetAll().ToList();
        // we can also use collection expressions List<Category> objCagoryList = [.. db.Categories];
        return View(objCategoryList);
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
            unitOfWork.Category.Add(formObj);
            unitOfWork.Save();
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
        Category? categoryFromDb = unitOfWork.Category.Get(u=>u.Id == id); // only works on primary key
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
            unitOfWork.Category.Update(formObj);
            unitOfWork.Save();
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
        Category? categoryFromDb = unitOfWork.Category.Get(u=>u.Id == id); // only works on primary key
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
            Category? obj = unitOfWork.Category.Get(u=>u.Id == id);
            if (obj == null) return NotFound();

            unitOfWork.Category.Remove(obj);
            unitOfWork.Save();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("index", "Category");
        }
        return View();
    }
};
