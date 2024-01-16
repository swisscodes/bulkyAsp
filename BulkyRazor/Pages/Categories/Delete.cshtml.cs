using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories;

public class DeleteModel(AppDbContext db) : PageModel
{
    [BindProperty]
    public required Category Category { get; set; }

    public void OnGet(int? id)
    {
        if (id != null && id>0)
        {
            Category = db.Categories.Find(id);

        }
    }

    public IActionResult OnPost()
    {
        Category? obj = db.Categories.Find(Category.Id);
        if (obj != null)
        {
            db.Categories.Remove(obj);
            db.SaveChanges();
            return RedirectToPage("index");
        }
        return NotFound();
    }
}
