using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    public class CreateModel(AppDbContext db) : PageModel()
    {
        public required Category Category { get; set; }
        public void OnGet()
        {
        }
    }
}
