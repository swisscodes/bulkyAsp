using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories;

public class EditModel(AppDbContext db) : PageModel
{
    [BindProperty]
    public required Category Category { get; set; }

    public void OnGet(int? id)
    {
        if (id != null && id!= 0)
        {
            Category = db.Categories.Find(id);

        }
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            db.Categories.Update(Category);
            db.SaveChanges();
            return RedirectToPage("index");
        }
        return Page();
    }
}
