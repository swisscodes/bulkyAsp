using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    //[BindProperties] this will bind all models or properties that we have in our class if more than one.
    public class CreateModel(AppDbContext db) : PageModel()
    {
        [BindProperty] // to bind properties individually
        public required Category Category { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.Categories.Add(Category);
            db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
