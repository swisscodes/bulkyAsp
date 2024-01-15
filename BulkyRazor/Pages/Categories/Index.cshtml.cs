using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    public class IndexModel(AppDbContext db ) : PageModel
    {
        public List<Category> CategoryList { get; set; } = [];
        public void OnGet()
        {
            CategoryList = db.Categories.ToList();
        }
    }
}
